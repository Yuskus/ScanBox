using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountepartyController : ControllerBase
    {
        private readonly ICrudMethodRepository<CounterpartyGetDTO, CounterpartyPostDTO> _counterpartyRepository;
        private readonly ILogger<CountepartyController> _logger;
        private readonly ITableConverter<CounterpartyGetDTO> _tableConverter;

        public CountepartyController(ICrudMethodRepository<CounterpartyGetDTO, CounterpartyPostDTO> counterpartyRepository, 
                                     ILogger<CountepartyController> logger, 
                                     ITableConverter<CounterpartyGetDTO> tableConverter)
        {
            _counterpartyRepository = counterpartyRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_counterparty")]
        public async Task<ActionResult<int>> AddCounterparty([FromBody] CounterpartyPostDTO counterpartyPostDTO)
        {
            try
            {
                var result = await _counterpartyRepository.Create(counterpartyPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a counterparty: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_counterparty")]
        public async Task<ActionResult<int>> PutCounterparty([FromBody] CounterpartyGetDTO counterpartyDTO)
        {
            try
            {
                var result = await _counterpartyRepository.Update(counterpartyDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a counterparty: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_counterparty")]
        public async Task<ActionResult<int>> DeleteCounterparty([FromBody] int counterpartyId)
        {
            try
            {
                var result = await _counterpartyRepository.Delete(counterpartyId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a counterparty: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_counterparties")]
        public async Task<ActionResult<IEnumerable<CounterpartyGetDTO>>> GetCounterparties()
        {
            try
            {
                var result = await _counterpartyRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of counterparty: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_counterparties_csv")]
        public async Task<ActionResult<string>> GetCounterpartiesAsCsv()
        {
            try
            {
                var list = await _counterpartyRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of counterparties as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
