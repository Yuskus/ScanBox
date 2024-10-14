using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
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

        public ManufacturerController(ICrudMethodRepository<ManufacturerGetDTO, ManufacturerPostDTO> manufacturerRepository, ILogger<ManufacturerController> logger)
        {
            _manufacturerRepository = manufacturerRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_manufacturer")]
        public ActionResult<int> AddManufacturer(ManufacturerPostDTO manufacturerPostDTO)
        {
            try
            {
                var result = _manufacturerRepository.Create(manufacturerPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a Manufacturer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_manufacturer")]
        public ActionResult<int> PutManufacturer(ManufacturerGetDTO manufacturerDTO)
        {
            try
            {
                var result = _manufacturerRepository.Update(manufacturerDTO);
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

        [HttpDelete(template: "delete_manufacturer")]
        public ActionResult<int> DeleteManufacturer(int manufacturerId)
        {
            try
            {
                var result = _manufacturerRepository.Delete(manufacturerId);
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

        [HttpGet(template: "get_manufacturers")]
        public ActionResult<IEnumerable<ManufacturerGetDTO>> GetManufacturers()
        {
            try
            {
                var result = _manufacturerRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Manufacturer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
