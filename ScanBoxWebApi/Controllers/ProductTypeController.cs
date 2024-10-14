﻿using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
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

        public ProductTypeController(ICrudMethodRepository<ProductTypeGetDTO, ProductTypePostDTO> productTypeRepository, ILogger<ProductTypeController> logger)
        {
            _productTypeRepository = productTypeRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_product_type")]
        public ActionResult<int> AddProductType(ProductTypePostDTO productTypePostDTO)
        {
            try
            {
                var result = _productTypeRepository.Create(productTypePostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a ProductType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_product_type")]
        public ActionResult<int> PutProductType(ProductTypeGetDTO productTypeDTO)
        {
            try
            {
                var result = _productTypeRepository.Update(productTypeDTO);
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

        [HttpDelete(template: "delete_product_type")]
        public ActionResult<int> DeleteProductType(int productTypeId)
        {
            try
            {
                var result = _productTypeRepository.Delete(productTypeId);
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

        [HttpGet(template: "get_product_types")]
        public ActionResult<IEnumerable<ProductTypeGetDTO>> GetProductTypes()
        {
            try
            {
                var result = _productTypeRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of ProductType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
