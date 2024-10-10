п»їusing DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;

namespace ScanBoxWebApi.Abstractions
{
    public interface IWarehouseEmployeeRepository : IDeleteRepository
    {
        public int AddWarehouseEmployee(WarehouseEmployeePostDTO warehouseEmployeePostDTO);
        public int PutWarehouseEmployee(WarehouseEmployeePostDTO warehouseEmployeePutDTO);
        public IEnumerable<WarehouseEmployeeGetDTO> GetWarehouseEmployeesPosts();
    }
}
