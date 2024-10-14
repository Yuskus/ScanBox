using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
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

        public CountepartyController(ICrudMethodRepository<CounterpartyGetDTO, CounterpartyPostDTO> counterpartyRepository, ILogger<CountepartyController> logger)
        {
            _counterpartyRepository = counterpartyRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_counterparty")]
        public ActionResult<int> AddCounterparty(CounterpartyPostDTO counterpartyPostDTO)
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

        [HttpPut(template: "put_counterparty")]
        public ActionResult<int> PutCounterparty(CounterpartyGetDTO counterpartyDTO)
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

        [HttpDelete(template: "delete_counterparty")]
        public ActionResult<int> DeleteCounterparty(int counterpartyId)
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
    }
}
