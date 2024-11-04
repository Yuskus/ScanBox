using ScanBoxWebApi.DTO.GetDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IShipmentComparer
    {
        Task<int> Compare(int documentId);
        Task<IEnumerable<ShipmentGetDTO>> GetMissingUnits(int documentId);
        Task<IEnumerable<ShipmentGetDTO>> GetUnwantedUnits(int documentId);
        Task<IEnumerable<ShipmentGetDTO>> GetFoundUnits(int documentId);
    }
}
