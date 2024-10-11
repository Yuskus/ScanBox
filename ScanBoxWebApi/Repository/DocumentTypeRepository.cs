using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class DocumentTypeRepository : ICrudMethodRepository<DocumentTypeGetDTO, DocumentTypePostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public DocumentTypeRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(DocumentTypePostDTO documentTypeDto)
        {
            var documentTypeEntity = _context.DocumentType.FirstOrDefault(x => x.DoctypeName == documentTypeDto.DoctypeName);
            if (documentTypeEntity == null)
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
            if (documentTypeEntity != null)
            {
                _context.Remove(documentTypeEntity);
                _context.SaveChanges();
                return documentTypeEntity.Id;
            }
            return -1;
        }

        public IEnumerable<DocumentTypeGetDTO> GetElemetsList()
        {
            var documentTypeEntity = _context.DocumentType.Select(x => _mapper.Map<DocumentTypeGetDTO>(x));
            return documentTypeEntity;
        }

        public int Update(DocumentTypeGetDTO documentTypeDto)
        {
            var documentTypeEntity = _context.DocumentType.FirstOrDefault(x => x.Id == documentTypeDto.Id);
            if (documentTypeEntity != null)
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
