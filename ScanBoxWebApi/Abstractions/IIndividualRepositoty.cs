using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IIndividualRepositoty : IRepository
    {
        public int AddIndividual(IndividualPostDTO individualPostDTO);
        public int PutIndividual(IndividualPostDTO individualPutDTO);
        public int DelIndividual(int individualId);
        public IEnumerable<IndividualGetDTO> GetIndividuals();
    }
}
