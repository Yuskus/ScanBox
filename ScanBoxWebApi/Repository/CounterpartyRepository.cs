using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class CounterpartyRepository : ICounterpartyRepository
    {
        public int AddCounterparty(CounterpartyPostDTO counterpartyPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CounterpartyGetDTO> GetCounterparties()
        {
            throw new NotImplementedException();
        }

        public int PutCounterparty(CounterpartyPostDTO counterpartyPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
