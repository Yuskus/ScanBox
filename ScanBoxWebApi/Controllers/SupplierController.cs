using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ICrudMethodRepository<SupplierGetDTO, SupplierPostDTO> _supplierRepository;
        private readonly ILogger<SupplierController> _logger;
        private readonly ITableConverter<SupplierGetDTO> _tableConverter;

        public SupplierController(ICrudMethodRepository<SupplierGetDTO, SupplierPostDTO> supplierRepository, 
                                  ILogger<SupplierController> logger, 
                                  ITableConverter<SupplierGetDTO> tableConverter)
        {
            _supplierRepository = supplierRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_supplier")]
        public async Task<ActionResult<int>> AddSupplier([FromBody] SupplierPostDTO supplierPostDTO)
        {
            try
            {
                var result = await _supplierRepository.Create(supplierPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a Supplier: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_supplier")]
        public async Task<ActionResult<int>> PutSupplier([FromBody] SupplierGetDTO supplierDTO)
        {
            try
            {
                var result = await _supplierRepository.Update(supplierDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a Supplier: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_supplier")]
        public async Task<ActionResult<int>> DeleteSupplier([FromBody] int supplierId)
        {
            try
            {
                var result = await _supplierRepository.Delete(supplierId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a Supplier: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_suppliers")]
        public async Task<ActionResult<IEnumerable<SupplierGetDTO>>> GetSuppliers()
        {
            try
            {
                var result = await _supplierRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Supplier: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_suppliers_csv")]
        public async Task<ActionResult<string>> GetSuppliersAsCsv()
        {
            try
            {
                var list = await _supplierRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of suppliers as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
