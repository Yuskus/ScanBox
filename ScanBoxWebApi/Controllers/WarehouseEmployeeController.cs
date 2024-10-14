using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseEmployeeController : ControllerBase
    {
        private readonly ICrudMethodRepository<WarehouseEmployeeGetDTO, WarehouseEmployeePostDTO> _warehouseEmployeeRepository;
        private readonly ILogger<WarehouseEmployeeController> _logger;

        public WarehouseEmployeeController(ICrudMethodRepository<WarehouseEmployeeGetDTO, WarehouseEmployeePostDTO> warehouseEmployeeRepository, ILogger<WarehouseEmployeeController> logger)
        {
            _warehouseEmployeeRepository = warehouseEmployeeRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_warehouse_employee")]
        public ActionResult<int> AddWarehouseEmployee(WarehouseEmployeePostDTO warehouseEmployeePostDTO)
        {
            try
            {
                var result = _warehouseEmployeeRepository.Create(warehouseEmployeePostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a WarehouseEmployee: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_warehouse_employee")]
        public ActionResult<int> PutWarehouseEmployee(WarehouseEmployeeGetDTO warehouseEmployeeDTO)
        {
            try
            {
                var result = _warehouseEmployeeRepository.Update(warehouseEmployeeDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a WarehouseEmployee: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "delete_warehouse_employee")]
        public ActionResult<int> DeleteWarehouseEmployee(int warehouseEmployeeId)
        {
            try
            {
                var result = _warehouseEmployeeRepository.Delete(warehouseEmployeeId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a WarehouseEmployee: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet(template: "get_warehouse_employees")]
        public ActionResult<IEnumerable<WarehouseEmployeeGetDTO>> GetWarehouseEmployees()
        {
            try
            {
                var result = _warehouseEmployeeRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of WarehouseEmployee: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
