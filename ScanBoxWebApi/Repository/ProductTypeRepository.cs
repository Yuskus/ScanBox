using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public int AddProductType(ProductTypePostDTO productTypePostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductTypeGetDTO> GetProductTypes()
        {
            throw new NotImplementedException();
        }

        public int PutProductType(ProductTypePostDTO productTypePutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
