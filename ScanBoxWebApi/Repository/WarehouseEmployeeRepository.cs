п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Repository
{
    public class WarehouseEmployeeRepository : IWarehouseEmployeeRepository
    {
        public int AddWarehouseEmployee(WarehouseEmployeePostDTO warehouseEmployeePostDTO)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WarehouseEmployeeGetDTO> GetWarehouseEmployeesPosts()
        {
            throw new NotImplementedException();
        }

        public int PutWarehouseEmployee(WarehouseEmployeePostDTO warehouseEmployeePutDTO)
        {
            throw new NotImplementedException();
        }
    }
}
