using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class BuyerRepository : IBuyerRepository
    {
        public int AddBuyer(BuyerPostDTO buyerPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BuyerGetDTO> GetBuyers()
        {
            throw new NotImplementedException();
        }

        public int PutBuyer(BuyerPostDTO buyerPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
