using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IProductCategoryRepository : IDeleteRepository
    {
        public int AddProductCategory(ProductCategoryPostDTO productCategoryPostDTO);
        public int PutProductCategory(ProductCategoryPostDTO productCategoryPutDTO);
        public int DelProductCategory(int productCategoryId);
        public IEnumerable<ProductCategoryGetDTO> GetProductCategories();
    }
}
