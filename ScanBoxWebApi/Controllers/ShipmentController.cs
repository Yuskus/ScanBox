﻿using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly ICrudMethodRepository<ShipmentGetDTO, ShipmentPostDTO> _shipmentRepository;
        private readonly ILogger<ShipmentController> _logger;
        private readonly ITableConverter<ShipmentGetDTO> _tableConverter;

        public ShipmentController(ICrudMethodRepository<ShipmentGetDTO, ShipmentPostDTO> shipmentRepository, 
                                  ILogger<ShipmentController> logger, 
                                  ITableConverter<ShipmentGetDTO> tableConverter)
        {
            _shipmentRepository = shipmentRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize]
        [HttpPost(template: "add_shipment")]
        public async Task<ActionResult<int>> AddShipment([FromBody] ShipmentPostDTO shipmentPostDTO)
        {
            try
            {
                var result = await _shipmentRepository.Create(shipmentPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a Shipment: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPut(template: "put_shipment")]
        public async Task<ActionResult<int>> PutShipment([FromBody] ShipmentGetDTO shipmentDTO)
        {
            try
            {
                var result = await _shipmentRepository.Update(shipmentDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a Shipment: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpDelete(template: "delete_shipment")]
        public async Task<ActionResult<int>> DeleteShipment([FromBody] int shipmentId)
        {
            try
            {
                var result = await _shipmentRepository.Delete(shipmentId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a Shipment: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_shipments")]
        public async Task<ActionResult<IEnumerable<ShipmentGetDTO>>> GetShipments()
        {
            try
            {
                var result = await _shipmentRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Shipment: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_shipments_csv")]
        public async Task<ActionResult<string>> GetShipmentsAsCsv()
        {
            try
            {
                var list = await _shipmentRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of shipments as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
