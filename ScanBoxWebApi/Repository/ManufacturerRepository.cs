using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ManufacturerRepository : ICrudMethodRepository<ManufacturerGetDTO, ManufacturerPostDTO>
    {
        public int Create(ManufacturerPostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ManufacturerGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(ManufacturerGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
