using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ProductCategoryRepository : ICrudMethodRepository<ProductCategoryGetDTO, ProductCategoryPostDTO>
    {
        public int Create(ProductCategoryPostDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategoryGetDTO> GetElemetsList()
        {
            throw new NotImplementedException();
        }

        public int Update(ProductCategoryGetDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
