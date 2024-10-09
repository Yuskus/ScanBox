using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        public int AddManufacturer(ManufacturerPostDTO manufacturerPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ManufacturerGetDTO> GetManufacturers()
        {
            throw new NotImplementedException();
        }

        public int PutManufacturer(ManufacturerPostDTO manufacturerPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
