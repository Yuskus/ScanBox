using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly ICrudMethodRepository<ProductTypeGetDTO, ProductTypePostDTO> _productTypeRepository;
        private readonly ILogger<ProductTypeController> _logger;
        private readonly ITableConverter<ProductTypeGetDTO> _tableConverter;

        public ProductTypeController(ICrudMethodRepository<ProductTypeGetDTO, ProductTypePostDTO> productTypeRepository, 
                                     ILogger<ProductTypeController> logger, 
                                     ITableConverter<ProductTypeGetDTO> tableConverter)
        {
            _productTypeRepository = productTypeRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize]
        [HttpPost(template: "add_product_type")]
        public async Task<ActionResult<int>> AddProductType([FromBody] ProductTypePostDTO productTypePostDTO)
        {
            try
            {
                var result = await _productTypeRepository.Create(productTypePostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a ProductType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPut(template: "put_product_type")]
        public async Task<ActionResult<int>> PutProductType([FromBody] ProductTypeGetDTO productTypeDTO)
        {
            try
            {
                var result = await _productTypeRepository.Update(productTypeDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a ProductType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpDelete(template: "delete_product_type")]
        public async Task<ActionResult<int>> DeleteProductType([FromBody] int productTypeId)
        {
            try
            {
                var result = await _productTypeRepository.Delete(productTypeId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a ProductType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_product_types")]
        public async Task<ActionResult<IEnumerable<ProductTypeGetDTO>>> GetProductTypes()
        {
            try
            {
                var result = await _productTypeRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of ProductType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_product_types_csv")]
        public async Task<ActionResult<string>> GetProductTypesAsCsv()
        {
            try
            {
                var list = await _productTypeRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of product types as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
