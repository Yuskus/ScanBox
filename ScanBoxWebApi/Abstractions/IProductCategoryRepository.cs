using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IProductCategoryRepository : IDeleteRepository
    {
        public int AddProductCategory(ProductCategoryPostDTO productCategoryPostDTO);
        public int PutProductCategory(ProductCategoryPostDTO productCategoryPutDTO);
        public IEnumerable<ProductCategoryGetDTO> GetProductCategories();
    }
}
