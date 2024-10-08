using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IIndividualRepositoty : IDeleteRepository
    {
        public int AddIndividual(IndividualPostDTO individualPostDTO);
        public int PutIndividual(IndividualPostDTO individualPutDTO);
        public IEnumerable<IndividualGetDTO> GetIndividuals();
    }
}
