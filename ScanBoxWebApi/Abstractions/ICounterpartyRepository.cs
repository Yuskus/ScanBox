using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ICounterpartyRepository : IDeleteRepository
    {
        public int AddCounterparty(CounterpartyPostDTO counterpartyPostDTO);
        public int PutCounterparty(CounterpartyPostDTO counterpartyPutDTO);
        public int DelCounterparty(int counterpartyId);
        public IEnumerable<CounterpartyGetDTO> GetCounterparties();

    }
}
