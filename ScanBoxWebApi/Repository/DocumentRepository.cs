using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

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

        public int Create(DocumentPostDTO documentDto)
        {
            var documentEntity = _context.Document.FirstOrDefault(x => x.Number == documentDto.Number);
            if (documentEntity == null)
            {
                documentEntity = _mapper.Map<DocumentEntity>(documentDto);
                _context.Add(documentEntity);
                _context.SaveChanges();
                _cache.Remove("documents");
            }
            return documentEntity.Id;
        }

        public int Delete(int documentId)
        {
            var documentEntity = _context.Document.FirstOrDefault(x => x.Id == documentId);
            int result = -1;
            if (documentEntity is not null)
            {
                result = documentEntity.Id;
                _context.Remove(documentEntity);
                _context.SaveChanges();
                _cache.Remove("documents");
            }
            return result;
        }

        public IEnumerable<DocumentGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("documents", out IEnumerable<DocumentGetDTO>? documents))
            {
                if (documents is not null) return documents;
            }
            var documentEntity = _context.Document.Select(x => _mapper.Map<DocumentGetDTO>(x)).ToList();
            _cache.Set("documents", documentEntity, TimeSpan.FromMinutes(30));
            return documentEntity;
        }

        public int Update(DocumentGetDTO documentDto)
        {
            var documentEntity = _context.Document.FirstOrDefault(x => x.Id == documentDto.Id);
            if (documentEntity is not null)
            {
                documentEntity.Number = documentDto.Number;
                documentEntity.CreationTime = documentDto.CreationTime;
                documentEntity.WarehouseEmployeeId = documentDto.WarehouseEmployeeId;
                documentEntity.DocumentTypeId = documentDto.DocumentTypeId;
                documentEntity.CounterpartyId = documentDto.CounterpartyId;
                
                _context.SaveChanges();
                _cache.Remove("documents");
                return documentEntity.Id;
            }
            return -1;
        }
    }
}
