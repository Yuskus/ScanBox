п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ICounterpartyTypeRepository : IDeleteRepository
    {
        public int AddCounterpartyType(CounterpartyTypePostDTO counterpartyTypePostDTO);
        public int PutCounterpartyType(CounterpartyTypePostDTO counterpartyTypePutDTO);
        public IEnumerable<CounterpartyTypeGetDTO> GetCounterpartiesType();
    }
}
