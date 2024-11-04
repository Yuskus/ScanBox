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
    public class DocumentTypeRepository : ICrudMethodRepository<DocumentTypeGetDTO, DocumentTypePostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public DocumentTypeRepository(ScanBoxDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<int> Create(DocumentTypePostDTO documentTypeDto)
        {
            var documentTypeEntity = await _context.DocumentType.FirstOrDefaultAsync(x => x.DoctypeName.ToLower() == documentTypeDto.DoctypeName.ToLower());
            if (documentTypeEntity is null)
            {
                documentTypeEntity = _mapper.Map<DocumentTypeEntity>(documentTypeDto);
                await _context.AddAsync(documentTypeEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("document_types");
            }
            return documentTypeEntity.Id;
        }

        public async Task<int> Delete(int documentTypeId)
        {
            var documentTypeEntity = await _context.DocumentType.FirstOrDefaultAsync(x => x.Id == documentTypeId);
            int result = -1;
            if (documentTypeEntity is not null)
            {
                result = documentTypeEntity.Id;
                _context.Remove(documentTypeEntity);
                await _context.SaveChangesAsync();
                _cache.Remove("document_types");
            }
            return result;
        }

        public async Task<IEnumerable<DocumentTypeGetDTO>> GetElemetsList()
        {
            if (_cache.TryGetValue("document_types", out IEnumerable<DocumentTypeGetDTO>? documentTypes))
            {
                if (documentTypes is not null) return documentTypes;
            }
            var documentTypeEntity = await _context.DocumentType.Select(x => _mapper.Map<DocumentTypeGetDTO>(x)).ToListAsync();
            _cache.Set("document_types", documentTypeEntity, TimeSpan.FromMinutes(30));
            return documentTypeEntity;
        }

        public async Task<int> Update(DocumentTypeGetDTO documentTypeDto)
        {
            var documentTypeEntity = await _context.DocumentType.FirstOrDefaultAsync(x => x.Id == documentTypeDto.Id);
            if (documentTypeEntity is not null)
            {
                documentTypeEntity.DoctypeName = documentTypeDto.DoctypeName;
                documentTypeEntity.Description = documentTypeDto.Description;

                await _context.SaveChangesAsync();
                _cache.Remove("document_types");
                return documentTypeEntity.Id;
            }
            return -1;
        }
    }
}
