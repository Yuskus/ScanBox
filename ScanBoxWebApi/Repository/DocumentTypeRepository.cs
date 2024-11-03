using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class DocumentTypeRepository : ICrudMethodRepository<DocumentTypeGetDTO, DocumentTypePostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

        public DocumentTypeRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(DocumentTypePostDTO documentTypeDto)
        {
            var documentTypeEntity = _context.DocumentType.FirstOrDefault(x => x.DoctypeName.Equals(documentTypeDto.DoctypeName, StringComparison.InvariantCultureIgnoreCase));
            if (documentTypeEntity is null)
            {
                documentTypeEntity = _mapper.Map<DocumentTypeEntity>(documentTypeDto);
                _context.Add(documentTypeEntity);
                _context.SaveChanges();
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
            }
            return result;
        }

        public IEnumerable<DocumentTypeGetDTO> GetElemetsList()
        {
            var documentTypeEntity = _context.DocumentType.Select(x => _mapper.Map<DocumentTypeGetDTO>(x)).ToList();
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
                return documentTypeEntity.Id;
            }
            return -1;
        }
    }
}
