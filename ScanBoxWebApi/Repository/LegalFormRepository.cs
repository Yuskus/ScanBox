using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class LegalFormRepository : ILegalFormRepository
    {
        public int AddLegalForm(LegalFormPostDTO legalFormPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LegalEntityGetDTO> GetLegalEntity()
        {
            throw new NotImplementedException();
        }

        public int PutLegalForm(LegalFormPostDTO legalFormPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
