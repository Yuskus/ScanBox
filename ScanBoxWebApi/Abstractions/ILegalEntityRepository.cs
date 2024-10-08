using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ILegalEntityRepository : IDeleteRepository
    {
        public int AddLegalEntity(LegalEntityPostDTO legalEntityPostDTO);
        public int PutLegalEntity(LegalEntityPostDTO legalEntityPutDTO);
        public int DelLegalEntity(int legalEntityId);
        public IEnumerable<LegalEntityGetDTO> GetLegalEntities();
    }
}
