using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class LegalEntityRepository : ILegalEntityRepository
    {
        public int AddLegalEntity(LegalEntityPostDTO legalEntityPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LegalEntityGetDTO> GetLegalEntities()
        {
            throw new NotImplementedException();
        }

        public int PutLegalEntity(LegalEntityPostDTO legalEntityPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
