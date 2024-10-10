using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class CounterpartyTypeRepository : ICounterpartyTypeRepository
    {
        public int AddCounterpartyType(CounterpartyTypePostDTO counterpartyTypePostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CounterpartyTypeGetDTO> GetCounterpartiesType()
        {
            throw new NotImplementedException();
        }

        public int PutCounterpartyType(CounterpartyTypePostDTO counterpartyTypePutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
