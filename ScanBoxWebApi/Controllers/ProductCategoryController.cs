using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
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

        public ProductCategoryController(ICrudMethodRepository<ProductCategoryGetDTO, ProductCategoryPostDTO> productCategoryRepository, ILogger<ProductCategoryController> logger)
        {
            _productCategoryRepository = productCategoryRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_product_category")]
        public ActionResult<int> AddProductCategory(ProductCategoryPostDTO productCategoryPostDTO)
        {
            try
            {
                var result = _productCategoryRepository.Create(productCategoryPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a ProductCategory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_product_category")]
        public ActionResult<int> PutProductCategory(ProductCategoryGetDTO productCategoryDTO)
        {
            try
            {
                var result = _productCategoryRepository.Update(productCategoryDTO);
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

        [HttpDelete(template: "delete_product_category")]
        public ActionResult<int> DeleteProductCategory(int productCategoryId)
        {
            try
            {
                var result = _productCategoryRepository.Delete(productCategoryId);
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

        [HttpGet(template: "get_product_categories")]
        public ActionResult<IEnumerable<ProductCategoryGetDTO>> GetProductCategories()
        {
            try
            {
                var result = _productCategoryRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of ProductCategory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
