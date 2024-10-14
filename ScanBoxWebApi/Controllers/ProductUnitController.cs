using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
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

        public ProductUnitController(ICrudMethodRepository<ProductUnitGetDTO, ProductUnitPostDTO> productUnitRepository, ILogger<ProductUnitController> logger)
        {
            _productUnitRepository = productUnitRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_product_unit")]
        public ActionResult<int> AddProductUnit(ProductUnitPostDTO productUnitPostDTO)
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

        [HttpPut(template: "put_product_unit")]
        public ActionResult<int> PutProductUnit(ProductUnitGetDTO productUnitDTO)
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

        [HttpDelete(template: "delete_product_unit")]
        public ActionResult<int> DeleteProductUnit(int productUnitId)
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
    }
}
