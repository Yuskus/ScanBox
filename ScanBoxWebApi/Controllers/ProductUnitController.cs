using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductUnitController : ControllerBase
    {
        private readonly ICrudMethodRepository<ProductUnitGetDTO, ProductUnitPostDTO> _productUnitRepository;
        private readonly ILogger<ProductUnitController> _logger;
        private readonly ITableConverter<ProductUnitGetDTO> _tableConverter;

        public ProductUnitController(ICrudMethodRepository<ProductUnitGetDTO, ProductUnitPostDTO> productUnitRepository, 
                                     ILogger<ProductUnitController> logger, 
                                     ITableConverter<ProductUnitGetDTO> tableConverter)
        {
            _productUnitRepository = productUnitRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize]
        [HttpPost(template: "add_product_unit")]
        public ActionResult<int> AddProductUnit([FromBody] ProductUnitPostDTO productUnitPostDTO)
        {
            try
            {
                var result = _productUnitRepository.Create(productUnitPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a ProductUnit: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPut(template: "put_product_unit")]
        public ActionResult<int> PutProductUnit([FromBody] ProductUnitGetDTO productUnitDTO)
        {
            try
            {
                var result = _productUnitRepository.Update(productUnitDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a ProductUnit: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpDelete(template: "delete_product_unit")]
        public ActionResult<int> DeleteProductUnit([FromBody] int productUnitId)
        {
            try
            {
                var result = _productUnitRepository.Delete(productUnitId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a ProductUnit: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_product_units")]
        public ActionResult<IEnumerable<ProductUnitGetDTO>> GetProductUnits()
        {
            try
            {
                var result = _productUnitRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of ProductUnit: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_product_units_csv")]
        public ActionResult<string> GetProductUnitsAsCsv()
        {
            try
            {
                var list = _productUnitRepository.GetElemetsList();
                var result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of product units as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
