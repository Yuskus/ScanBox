using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IPricesRepository : IRepository
    {
        public int AddPrices(PricesPostDTO pricesPostDTO);
        public int PutPrices(PricesPostDTO pricesPutDTO);
        public int DelPrices(int pricesId);
        public IEnumerable<PricesGetDTO> GetPrices();
    }
}
