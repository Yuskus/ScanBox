namespace ScanBoxWebApi.Abstractions
{
    public interface ICrudMethodRepository<TGetDTO, TPostDTO>
        where TGetDTO : class
        where TPostDTO : class
    {
        public Task<int> Create(TPostDTO dto);
        public Task<int> Update(TGetDTO dto);
        public Task<int> Delete(int Id);
        public Task<IEnumerable<TGetDTO>> GetElemetsList();
    }
}
