namespace ScanBoxWebApi.Abstractions
{
    public interface ICrudMethodRepository<TGetDTO, TPostDTO>
        where TGetDTO : class
        where TPostDTO : class
    {
        public int Create(TPostDTO dto);
        public int Update(TPostDTO dto);
        public int Delete(int Id);
        public IEnumerable<TGetDTO> GetElemetsList();
    }
}
