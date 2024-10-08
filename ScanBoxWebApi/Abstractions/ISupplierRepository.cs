using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface ISupplierRepository : IDeleteRepository
    {
        public int AddSupplier(SupplierPostDTO supplierPostDTO);
        public int PutSupplier(SupplierPostDTO supplierPuttDTO);
        public IEnumerable<SupplierGetDTO> GetSupplier();
    }
}
