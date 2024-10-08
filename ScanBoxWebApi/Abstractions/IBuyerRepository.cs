using DatabaseModel;
using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IBuyerRepository : IRepository
    {
        public int AddBuyer(BuyerPostDTO buyerPostDTO);
        public int DelBuyer(int buyerId);
        public IEnumerable <BuyerGetDTO> GetBuyers();

    }
}
