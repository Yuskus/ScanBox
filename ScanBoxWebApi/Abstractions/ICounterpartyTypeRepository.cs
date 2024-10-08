using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ICounterpartyTypeRepository : IRepository
    {
        public int AddCounterpartyType (CounterpartyTypePostDTO counterpartyTypePostDTO);
        public int PutCounterpartyType(CounterpartyTypePostDTO counterpartyTypePutDTO);
        public int DeleteCounterpartyType(int counterpartyTypeId);
        public IEnumerable<CounterpartyTypeGetDTO> counterpartiesTypeGetDTO();        
    }
}
