using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class ProductUnitRepository : IProductUnitRepository
    {
        public int AddProductUnit(ProductUnitPostDTO productUnitPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductUnitGetDTO> GetProductUnits()
        {
            throw new NotImplementedException();
        }

        public int PutProductUnit(ProductUnitPostDTO productUnitPutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
