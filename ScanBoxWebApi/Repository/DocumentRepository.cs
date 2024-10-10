using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class DocumentRepository : ICrudMethodRepository<DocumentGetDTO, DocumentPostDTO>
    {
        public readonly ScanBoxDbContext _context;
        public readonly IMapper _mapper;

        public DocumentRepository(ScanBoxDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(DocumentPostDTO documentDto)
        {
            var documentEntity = _context.Document.FirstOrDefault(x => x.Number == documentDto.Number);
            if (documentEntity == null)
            {
                documentEntity = _mapper.Map<DocumentEntity>(documentDto);
                _context.Add(documentEntity);
                _context.SaveChanges();                
            }
            return documentEntity.Id;

        }

        public int Delete(int documentId)
        {
            var documentEntity = _context.Document.FirstOrDefault(x => x.Id == documentId);
            if (documentEntity != null)
            {
                _context.Remove(documentEntity);
                _context.SaveChanges();
                return documentEntity.Id;
            }
            return -1;
        }

        public IEnumerable<DocumentGetDTO> GetElemetsList()
        {
            var documentEntity = _context.Document.Select(x => _mapper.Map<DocumentGetDTO>(x));
            return documentEntity;
        }

        public int Update(DocumentGetDTO documentDto)
        {
            var documentEntity = _context.Document.FirstOrDefault(x => x.Id == documentDto.Id);
            if (documentEntity != null)
            {
                documentEntity.Number = documentDto.Number;
                documentEntity.CreationTime = documentDto.CreationTime;
                documentEntity.WarehouseEmployeeId = documentDto.WarehouseEmployeeId;
                documentEntity.DocumentTypeId = documentDto.DocumentTypeId;
                documentEntity.CounterpartyId = documentDto.CounterpartyId;
                
                _context.SaveChanges();
                return documentEntity.Id;
            }
            return -1;
        }
    }
}
