using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IDocumentTypeRepository : IDeleteRepository
    {
        public int AddDocumentType(DocumentTypePostDTO documentTypePostDTO);
        public int PutDocumentType(DocumentTypePostDTO documentTypePutDTO);
        public int DelDocumentType(int documentTypeId);
        public IEnumerable<DocumentTypeGetDTO> GetDocumentTypes();
    }
}
