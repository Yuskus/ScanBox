using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ILegalFormRepository : IRepository
    {
        public int AddLegalForm(LegalFormPostDTO legalFormPostDTO);
        public int PutLegalForm(LegalFormPostDTO legalFormPutDTO);
        public int DelLegalForm(int legalFormId);
        public IEnumerable<LegalEntityGetDTO> GetLegalEntity();
    }
}
