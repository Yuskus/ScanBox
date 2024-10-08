using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IProductUnitRepository : IRepository
    {
        public int AddProductUnit(ProductUnitPostDTO productUnitPostDTO);
        public int PutProductUnit(ProductUnitPostDTO productUnitPutDTO);
        public int DelProductUnit(int productUnitId);
        public IEnumerable<ProductUnitGetDTO> GetProductUnits();
    }
}
