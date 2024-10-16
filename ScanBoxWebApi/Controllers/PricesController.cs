using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly ICrudMethodRepository<PricesGetDTO, PricesPostDTO> _pricesRepository;
        private readonly ILogger<PricesController> _logger;

        public PricesController(ICrudMethodRepository<PricesGetDTO, PricesPostDTO> pricesRepository, ILogger<PricesController> logger)
        {
            _pricesRepository = pricesRepository;
            _logger = logger;
        }

        [Authorize]
        [HttpPost(template: "add_prices")]
        public ActionResult<int> AddPrices([FromBody] PricesPostDTO pricesPostDTO)
        {
            try
            {
                var result = _pricesRepository.Create(pricesPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a Prices: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPut(template: "put_prices")]
        public ActionResult<int> PutPrices([FromBody] PricesGetDTO pricesDTO)
        {
            try
            {
                var result = _pricesRepository.Update(pricesDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a Prices: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpDelete(template: "delete_prices")]
        public ActionResult<int> DeletePrices([FromBody] int priceId)
        {
            try
            {
                var result = _pricesRepository.Delete(priceId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a Prices: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_prices")]
        public ActionResult<IEnumerable<PricesGetDTO>> GetPrices()
        {
            try
            {
                var result = _pricesRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Prices: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
