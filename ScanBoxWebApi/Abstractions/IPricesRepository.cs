using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IPricesRepository : IDeleteRepository
    {
        public int AddPrices(PricesPostDTO pricesPostDTO);
        public int PutPrices(PricesPostDTO pricesPutDTO);
        public IEnumerable<PricesGetDTO> GetPrices();
    }
}
