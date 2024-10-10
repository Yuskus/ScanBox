п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IShipmentRepository : IDeleteRepository
    {
        public int AddShipment(ShipmentPostDTO shipmentPostDTO);
        public int PutShipment(ShipmentPostDTO shipmentPutDTO);
        public IEnumerable<ShipmentGetDTO> GetShipment();
    }
}
