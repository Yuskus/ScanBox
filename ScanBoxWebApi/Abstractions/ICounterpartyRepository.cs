using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ICounterpartyRepository : IRepository
    {
        public int AddCounterparty(CounterpartyPostDTO counterpartyPostDTO);
        public int PutCounterparty(CounterpartyPostDTO counterpartyPutDTO);
        public int DeleteCounterparty(int counterpartyId);
        public IEnumerable<CounterpartyGetDTO> GetCounterparties();

    }
}
