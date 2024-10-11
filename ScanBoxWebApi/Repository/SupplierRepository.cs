using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class SupplierRepository : ICrudMethodRepository<SupplierGetDTO, SupplierPostDTO>
    {
        public int Create(SupplierPostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(SupplierGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
