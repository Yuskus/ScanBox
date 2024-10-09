namespace ScanBoxWebApi.Abstractions
{
    public interface IGenericMethodsDTO<DTO>
    {
        public int Create (DTO dto);
        public int Update (DTO dto);
        public int Delete (int Id);
        public IEnumerable<DTO> GetElemetsList ();
    }
}
