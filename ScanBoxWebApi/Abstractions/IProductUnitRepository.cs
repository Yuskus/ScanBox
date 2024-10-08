using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IProductUnitRepository : IDeleteRepository
    {
        public int AddProductUnit(ProductUnitPostDTO productUnitPostDTO);
        public int PutProductUnit(ProductUnitPostDTO productUnitPutDTO);
        public int DelProductUnit(int productUnitId);
        public IEnumerable<ProductUnitGetDTO> GetProductUnits();
    }
}
