using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;

namespace ScanBoxWebApi.Repository
{
    public class DocumentRepository : ICrudMethodRepository<DocumentGetDTO, DocumentPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public DocumentRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<int> Create(DocumentPostDTO documentDto)
        {
            var documentEntity = await _context.Document.FirstOrDefaultAsync(x => x.Number == documentDto.Number);
            if (documentEntity == null)
            {
                documentEntity = _mapper.Map<DocumentEntity>(documentDto);
                await _context.AddAsync(documentEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("documents");
            }
            return documentEntity.Id;
        }

        public async Task<int> Delete(int documentId)
        {
            var documentEntity = await _context.Document.FirstOrDefaultAsync(x => x.Id == documentId);
            int result = -1;
            if (documentEntity is not null)
            {
                result = documentEntity.Id;
                _context.Remove(documentEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("documents");
            }
            return result;
        }

        public async Task<IEnumerable<DocumentGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("documents", out IEnumerable<DocumentGetDTO>? documents))
            {
                if (documents is not null) return documents;
            }
            var documentEntity = await _context.Document.Select(x => _mapper.Map<DocumentGetDTO>(x)).ToListAsync();
            _cache.Set("documents", documentEntity, TimeSpan.FromMinutes(30));
            return documentEntity;
        }

        public async Task<int> Update(DocumentGetDTO documentDto)
        {
            var documentEntity = await _context.Document.FirstOrDefaultAsync(x => x.Id == documentDto.Id);
            if (documentEntity is not null)
            {
                documentEntity.Number = documentDto.Number;
                documentEntity.CreationTime = documentDto.CreationTime;
                documentEntity.WarehouseEmployeeId = documentDto.WarehouseEmployeeId;
                documentEntity.DocumentTypeId = documentDto.DocumentTypeId;
                documentEntity.CounterpartyId = documentDto.CounterpartyId;
                
                await _context.SaveChangesAsync();
                _cache.Remove("documents");
                return documentEntity.Id;
            }
            return -1;
        }
    }
}
