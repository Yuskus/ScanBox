namespace ScanBoxWebApi.Abstractions
{
    public interface IShipmentComparer<T>
    {
        int Compare(int documentId);
        IEnumerable<T> GetMissingUnits(int documentId);
        IEnumerable<T> GetUnwantedUnits(int documentId);
        IEnumerable<T> GetFoundUnits(int documentId);
    }
}
