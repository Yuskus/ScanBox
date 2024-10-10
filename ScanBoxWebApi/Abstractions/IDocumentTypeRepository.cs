п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IDocumentTypeRepository : IDeleteRepository
    {
        public int AddDocumentType(DocumentTypePostDTO documentTypePostDTO);
        public int PutDocumentType(DocumentTypePostDTO documentTypePutDTO);
        public IEnumerable<DocumentTypeGetDTO> GetDocumentTypes();
    }
}
