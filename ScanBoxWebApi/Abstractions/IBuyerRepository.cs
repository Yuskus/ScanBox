using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IBuyerRepository : IRepository
    {
        public int AddBuyer(BuyerPostDTO buyerPostDTO);
        public int PutBuyer(BuyerPostDTO buyerPutDTO);
        public int DelBuyer(int buyerId);
        public IEnumerable<BuyerGetDTO> GetBuyers();

    }
}
