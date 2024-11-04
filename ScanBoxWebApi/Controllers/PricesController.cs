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
        private readonly ITableConverter<PricesGetDTO> _tableConverter;

        public PricesController(ICrudMethodRepository<PricesGetDTO, PricesPostDTO> pricesRepository, 
                                ILogger<PricesController> logger, 
                                ITableConverter<PricesGetDTO> tableConverter)
        {
            _pricesRepository = pricesRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize]
        [HttpPost(template: "add_prices")]
        public async Task<ActionResult<int>> AddPrices([FromBody] PricesPostDTO pricesPostDTO)
        {
            try
            {
                var result = await _pricesRepository.Create(pricesPostDTO);
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
        public async Task<ActionResult<int>> PutPrices([FromBody] PricesGetDTO pricesDTO)
        {
            try
            {
                var result = await _pricesRepository.Update(pricesDTO);
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
        public async Task<ActionResult<int>> DeletePrices([FromBody] int priceId)
        {
            try
            {
                var result = await _pricesRepository.Delete(priceId);
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
        public async Task<ActionResult<IEnumerable<PricesGetDTO>>> GetPrices()
        {
            try
            {
                var result = await _pricesRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Prices: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_prices_csv")]
        public async Task<ActionResult<string>> GetPricesAsCsv()
        {
            try
            {
                var list = await _pricesRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of prices as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
