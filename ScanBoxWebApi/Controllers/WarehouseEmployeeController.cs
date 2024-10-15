using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_warehouse_employee")]
        public ActionResult<int> AddWarehouseEmployee([FromBody] WarehouseEmployeePostDTO warehouseEmployeePostDTO)
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

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_warehouse_employee")]
        public ActionResult<int> PutWarehouseEmployee([FromBody] WarehouseEmployeeGetDTO warehouseEmployeeDTO)
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

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_warehouse_employee")]
        public ActionResult<int> DeleteWarehouseEmployee([FromBody] int warehouseEmployeeId)
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

        [Authorize]
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
