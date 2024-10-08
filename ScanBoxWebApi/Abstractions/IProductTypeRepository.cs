using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IProductTypeRepository : IRepository
    {
        public int AddProductType(ProductTypePostDTO productTypePostDTO);
        public int PutProductType(ProductTypePostDTO productTypePutDTO);
        public int DelProductType(int productTypeId);
        public IEnumerable<ProductTypeGetDTO> GetProductTypes();
    }
}
