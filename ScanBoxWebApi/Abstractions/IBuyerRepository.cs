using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IBuyerRepository : IDeleteRepository
    {
        public int AddBuyer(BuyerPostDTO buyerPostDTO);
        public int PutBuyer(BuyerPostDTO buyerPutDTO);
        public IEnumerable<BuyerGetDTO> GetBuyers();
    }
}
