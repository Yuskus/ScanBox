п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        public int AddDocumentType(DocumentTypePostDTO documentTypePostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentTypeGetDTO> GetDocumentTypes()
        {
            throw new NotImplementedException();
        }

        public int PutDocumentType(DocumentTypePostDTO documentTypePutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
