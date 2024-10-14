using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
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

        public ShipmentController(ICrudMethodRepository<ShipmentGetDTO, ShipmentPostDTO> shipmentRepository, ILogger<ShipmentController> logger)
        {
            _shipmentRepository = shipmentRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_shipment")]
        public ActionResult<int> AddShipment(ShipmentPostDTO shipmentPostDTO)
        {
            try
            {
                var result = _shipmentRepository.Create(shipmentPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a Shipment: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_shipment")]
        public ActionResult<int> PutShipment(ShipmentGetDTO shipmentDTO)
        {
            try
            {
                var result = _shipmentRepository.Update(shipmentDTO);
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

        [HttpDelete(template: "delete_shipment")]
        public ActionResult<int> DeleteShipment(int shipmentId)
        {
            try
            {
                var result = _shipmentRepository.Delete(shipmentId);
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

        [HttpGet(template: "get_shipments")]
        public ActionResult<IEnumerable<ShipmentGetDTO>> GetShipments()
        {
            try
            {
                var result = _shipmentRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Shipment: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
