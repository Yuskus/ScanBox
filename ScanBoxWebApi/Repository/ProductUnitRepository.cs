using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ProductUnitRepository : ICrudMethodRepository<ProductUnitGetDTO, ProductUnitPostDTO>
    {
        public int Create(ProductUnitPostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductUnitGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(ProductUnitGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
