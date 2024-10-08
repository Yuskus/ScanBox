using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IDocumentRepository : IDeleteRepository
    {
        public int AddDocument(DocumentPostDTO documentPostDTO);
        public int PutDocument(DocumentPostDTO documentPutDTO);
        public int DelDocument(int documentId);
        public IEnumerable<DocumentGetDTO> GetDocuments();

    }
}
