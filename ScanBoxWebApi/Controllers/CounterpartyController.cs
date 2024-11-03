using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Repository;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountepartyController : ControllerBase
    {
        private readonly ICrudMethodRepository<CounterpartyGetDTO, CounterpartyPostDTO> _counterpartyRepository;
        private readonly ILogger<CountepartyController> _logger;
        private readonly ITableConverter<CounterpartyGetDTO> _tableConverter;

        public CountepartyController(ICrudMethodRepository<CounterpartyGetDTO, CounterpartyPostDTO> counterpartyRepository, ILogger<CountepartyController> logger, ITableConverter<CounterpartyGetDTO> tableConverter)
        {
            _counterpartyRepository = counterpartyRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_counterparty")]
        public ActionResult<int> AddCounterparty([FromBody] CounterpartyPostDTO counterpartyPostDTO)
        {
            try
            {
                var result = _counterpartyRepository.Create(counterpartyPostDTO);
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
        public ActionResult<int> PutCounterparty([FromBody] CounterpartyGetDTO counterpartyDTO)
        {
            try
            {
                var result = _counterpartyRepository.Update(counterpartyDTO);
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
        public ActionResult<int> DeleteCounterparty([FromBody] int counterpartyId)
        {
            try
            {
                var result = _counterpartyRepository.Delete(counterpartyId);
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
        public ActionResult<IEnumerable<CounterpartyGetDTO>> GetCounterparties()
        {
            try
            {
                var result = _counterpartyRepository.GetElemetsList();
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
        public ActionResult<string> GetCounterpartiesAsCsv()
        {
            try
            {
                var list = _counterpartyRepository.GetElemetsList();
                var result = _tableConverter.Convert(list);
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
