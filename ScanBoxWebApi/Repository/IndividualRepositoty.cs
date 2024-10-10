using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class IndividualRepositoty : IIndividualRepositoty
    {
        public int AddIndividual(IndividualPostDTO individualPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IndividualGetDTO> GetIndividuals()
        {
            throw new NotImplementedException();
        }

        public int PutIndividual(IndividualPostDTO individualPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
