using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ProductTypeRepository : ICrudMethodRepository<ProductTypeGetDTO, ProductTypePostDTO>
    {
        public int Create(ProductTypePostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTypeGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(ProductTypeGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
