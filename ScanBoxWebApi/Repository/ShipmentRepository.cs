using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ShipmentRepository : ICrudMethodRepository<ShipmentGetDTO, ShipmentPostDTO>
    {
        public int Create(ShipmentPostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShipmentGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(ShipmentGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
