using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ICrudMethodRepository<ProductCategoryGetDTO, ProductCategoryPostDTO> _productCategoryRepository;
        private readonly ILogger<ProductCategoryController> _logger;
        private readonly ITableConverter<ProductCategoryGetDTO> _tableConverter;

        public ProductCategoryController(ICrudMethodRepository<ProductCategoryGetDTO, ProductCategoryPostDTO> productCategoryRepository, 
                                         ILogger<ProductCategoryController> logger, 
                                         ITableConverter<ProductCategoryGetDTO> tableConverter)
        {
            _productCategoryRepository = productCategoryRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_product_category")]
        public async Task<ActionResult<int>> AddProductCategory([FromBody] ProductCategoryPostDTO productCategoryPostDTO)
        {
            try
            {
                var result = await _productCategoryRepository.Create(productCategoryPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a ProductCategory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_product_category")]
        public async Task<ActionResult<int>> PutProductCategory([FromBody] ProductCategoryGetDTO productCategoryDTO)
        {
            try
            {
                var result = await _productCategoryRepository.Update(productCategoryDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a ProductCategory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_product_category")]
        public async Task<ActionResult<int>> DeleteProductCategory([FromBody] int productCategoryId)
        {
            try
            {
                var result = await _productCategoryRepository.Delete(productCategoryId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a ProductCategory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_product_categories")]
        public async Task<ActionResult<IEnumerable<ProductCategoryGetDTO>>> GetProductCategories()
        {
            try
            {
                var result = await _productCategoryRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of ProductCategory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_product_categories_csv")]
        public async Task<ActionResult<string>> GetProductCategoriesAsCsv()
        {
            try
            {
                var list = await _productCategoryRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of product categories as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
