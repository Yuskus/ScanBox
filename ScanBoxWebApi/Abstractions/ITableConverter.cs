namespace ScanBoxWebApi.Abstractions
{
    public interface ITableConverter<T> where T : class
    {
        public string Convert(IEnumerable<T> array);
    }
}
