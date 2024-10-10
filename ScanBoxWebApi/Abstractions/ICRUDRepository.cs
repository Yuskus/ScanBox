п»їnamespace ScanBoxWebApi.Abstractions
{
    public interface ICRUDRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetOne(int id);
        public int AddOne(T entity);
        public int UpdateOne(T entity);
        public int DeleteOne(int id);
    }
}
