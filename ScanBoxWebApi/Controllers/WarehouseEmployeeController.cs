using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
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
        private readonly ITableConverter<WarehouseEmployeeGetDTO> _tableConverter;

        public WarehouseEmployeeController(ICrudMethodRepository<WarehouseEmployeeGetDTO, WarehouseEmployeePostDTO> warehouseEmployeeRepository, 
                                           ILogger<WarehouseEmployeeController> logger, 
                                           ITableConverter<WarehouseEmployeeGetDTO> tableConverter)
        {
            _warehouseEmployeeRepository = warehouseEmployeeRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_warehouse_employee")]
        public async Task<ActionResult<int>> AddWarehouseEmployee([FromBody] WarehouseEmployeePostDTO warehouseEmployeePostDTO)
        {
            try
            {
                var result = await _warehouseEmployeeRepository.Create(warehouseEmployeePostDTO);
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
        public async Task<ActionResult<int>> PutWarehouseEmployee([FromBody] WarehouseEmployeeGetDTO warehouseEmployeeDTO)
        {
            try
            {
                var result = await _warehouseEmployeeRepository.Update(warehouseEmployeeDTO);
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
        public async Task<ActionResult<int>> DeleteWarehouseEmployee([FromBody] int warehouseEmployeeId)
        {
            try
            {
                var result = await _warehouseEmployeeRepository.Delete(warehouseEmployeeId);
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
        public async Task<ActionResult<IEnumerable<WarehouseEmployeeGetDTO>>> GetWarehouseEmployees()
        {
            try
            {
                var result = await _warehouseEmployeeRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of WarehouseEmployee: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_warehouse_employees_csv")]
        public async Task<ActionResult<string>> GetWarehouseEmployeesAsCsv()
        {
            try
            {
                var list = await _warehouseEmployeeRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of warehouse employees as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
