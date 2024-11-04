using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;
using Microsoft.Extensions.Caching.Memory;

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

        public int Create(DocumentTypePostDTO documentTypeDto)
        {
            var documentTypeEntity = _context.DocumentType.FirstOrDefault(x => x.DoctypeName.ToLower() == documentTypeDto.DoctypeName.ToLower());
            if (documentTypeEntity is null)
            {
                documentTypeEntity = _mapper.Map<DocumentTypeEntity>(documentTypeDto);
                _context.Add(documentTypeEntity);
                _context.SaveChanges();
                _cache.Remove("document_types");
            }
            return documentTypeEntity.Id;
        }

        public int Delete(int documentTypeId)
        {
            var documentTypeEntity = _context.DocumentType.FirstOrDefault(x => x.Id == documentTypeId);
            int result = -1;
            if (documentTypeEntity is not null)
            {
                result = documentTypeEntity.Id;
                _context.Remove(documentTypeEntity);
                _context.SaveChanges();
                _cache.Remove("document_types");
            }
            return result;
        }

        public IEnumerable<DocumentTypeGetDTO> GetElemetsList()
        {
            if (_cache.TryGetValue("document_types", out IEnumerable<DocumentTypeGetDTO>? documentTypes))
            {
                if (documentTypes is not null) return documentTypes;
            }
            var documentTypeEntity = _context.DocumentType.Select(x => _mapper.Map<DocumentTypeGetDTO>(x)).ToList();
            _cache.Set("document_types", documentTypeEntity, TimeSpan.FromMinutes(30));
            return documentTypeEntity;
        }

        public int Update(DocumentTypeGetDTO documentTypeDto)
        {
            var documentTypeEntity = _context.DocumentType.FirstOrDefault(x => x.Id == documentTypeDto.Id);
            if (documentTypeEntity is not null)
            {
                documentTypeEntity.DoctypeName = documentTypeDto.DoctypeName;
                documentTypeEntity.Description = documentTypeDto.Description;
                
                _context.SaveChanges();
                _cache.Remove("document_types");
                return documentTypeEntity.Id;
            }
            return -1;
        }
    }
}
