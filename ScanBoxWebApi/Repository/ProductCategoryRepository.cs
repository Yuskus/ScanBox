п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        public int AddProductCategory(ProductCategoryPostDTO productCategoryPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategoryGetDTO> GetProductCategories()
        {
            throw new NotImplementedException();
        }

        public int PutProductCategory(ProductCategoryPostDTO productCategoryPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
