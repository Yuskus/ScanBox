п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        public int AddDocument(DocumentPostDTO documentPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DocumentGetDTO> GetDocuments()
        {
            throw new NotImplementedException();
        }

        public int PutDocument(DocumentPostDTO documentPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
