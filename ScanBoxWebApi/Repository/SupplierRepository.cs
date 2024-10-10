п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        public int AddSupplier(SupplierPostDTO supplierPostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplierGetDTO> GetSupplier()
        {
            throw new NotImplementedException();
        }

        public int PutSupplier(SupplierPostDTO supplierPuttDTO)
        {
            throw new NotImplementedException();
        }
    }
}
