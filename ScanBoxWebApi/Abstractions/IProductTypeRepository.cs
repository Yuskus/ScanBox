using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IProductTypeRepository : IDeleteRepository
    {
        public int AddProductType(ProductTypePostDTO productTypePostDTO);
        public int PutProductType(ProductTypePostDTO productTypePutDTO);
        public IEnumerable<ProductTypeGetDTO> GetProductTypes();
    }
}
