﻿using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly ICrudMethodRepository<ManufacturerGetDTO, ManufacturerPostDTO> _manufacturerRepository;
        private readonly ILogger<ManufacturerController> _logger;
        private readonly ITableConverter<ManufacturerGetDTO> _tableConverter;

        public ManufacturerController(ICrudMethodRepository<ManufacturerGetDTO, ManufacturerPostDTO> manufacturerRepository, 
                                      ILogger<ManufacturerController> logger, 
                                      ITableConverter<ManufacturerGetDTO> tableConverter)
        {
            _manufacturerRepository = manufacturerRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_manufacturer")]
        public async Task<ActionResult<int>> AddManufacturer([FromBody] ManufacturerPostDTO manufacturerPostDTO)
        {
            try
            {
                var result = await _manufacturerRepository.Create(manufacturerPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a Manufacturer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_manufacturer")]
        public async Task<ActionResult<int>> PutManufacturer([FromBody] ManufacturerGetDTO manufacturerDTO)
        {
            try
            {
                var result = await _manufacturerRepository.Update(manufacturerDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a Manufacturer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_manufacturer")]
        public async Task<ActionResult<int>> DeleteManufacturer([FromBody] int manufacturerId)
        {
            try
            {
                var result = await _manufacturerRepository.Delete(manufacturerId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a Manufacturer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_manufacturers")]
        public async Task<ActionResult<IEnumerable<ManufacturerGetDTO>>> GetManufacturers()
        {
            try
            {
                var result = await _manufacturerRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Manufacturer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_manufacturers_csv")]
        public async Task<ActionResult<string>> GetManufacturersAsCsv()
        {
            try
            {
                var list = await _manufacturerRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of manufacturers as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
