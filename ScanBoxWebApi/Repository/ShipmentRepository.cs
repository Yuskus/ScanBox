п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        public int AddShipment(ShipmentPostDTO shipmentPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShipmentGetDTO> GetShipment()
        {
            throw new NotImplementedException();
        }

        public int PutShipment(ShipmentPostDTO shipmentPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
