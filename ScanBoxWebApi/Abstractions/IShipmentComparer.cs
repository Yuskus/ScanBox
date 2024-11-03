using ScanBoxWebApi.DTO.GetDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IShipmentComparer
    {
        int Compare(int documentId);
        IEnumerable<ShipmentGetDTO> GetMissingUnits(int documentId);
        IEnumerable<ShipmentGetDTO> GetUnwantedUnits(int documentId);
        IEnumerable<ShipmentGetDTO> GetFoundUnits(int documentId);
    }
}
