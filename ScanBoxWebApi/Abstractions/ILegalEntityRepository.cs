using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ILegalEntityRepository : IDeleteRepository
    {
        public int AddLegalEntity(LegalEntityPostDTO legalEntityPostDTO);
        public int PutLegalEntity(LegalEntityPostDTO legalEntityPutDTO);
        public IEnumerable<LegalEntityGetDTO> GetLegalEntities();
    }
}
