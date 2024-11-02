using AutoMapper;
using DatabaseModel;
using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class DocumentRepository : ICrudMethodRepository<DocumentGetDTO, DocumentPostDTO>
    {
        private readonly ScanBoxDbContext _context;
        private readonly IMapper _mapper;

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
            int result = -1;
            if (documentEntity is not null)
            {
                result = documentEntity.Id;
                _context.Remove(documentEntity);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<DocumentGetDTO> GetElemetsList()
        {
            var documentEntity = _context.Document.Select(x => _mapper.Map<DocumentGetDTO>(x)).ToList();
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
                return documentEntity.Id;
            }
            return -1;
        }
    }
}
