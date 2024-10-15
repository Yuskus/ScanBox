﻿using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
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

        public SupplierController(ICrudMethodRepository<SupplierGetDTO, SupplierPostDTO> supplierRepository, ILogger<SupplierController> logger)
        {
            _supplierRepository = supplierRepository;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_supplier")]
        public ActionResult<int> AddSupplier([FromBody] SupplierPostDTO supplierPostDTO)
        {
            try
            {
                var result = _supplierRepository.Create(supplierPostDTO);
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
        public ActionResult<int> PutSupplier([FromBody] SupplierGetDTO supplierDTO)
        {
            try
            {
                var result = _supplierRepository.Update(supplierDTO);
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
        public ActionResult<int> DeleteSupplier([FromBody] int supplierId)
        {
            try
            {
                var result = _supplierRepository.Delete(supplierId);
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
        public ActionResult<IEnumerable<SupplierGetDTO>> GetSuppliers()
        {
            try
            {
                var result = _supplierRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Supplier: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
