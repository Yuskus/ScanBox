using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IManufacturerRepository : IDeleteRepository
    {
        public int AddManufacturer(ManufacturerPostDTO manufacturerPostDTO);
        public int PutManufacturer(ManufacturerPostDTO manufacturerPutDTO);
        public int DelManufacturer(int manufacturerId);
        public IEnumerable<ManufacturerGetDTO> GetManufacturers();
    }
}
