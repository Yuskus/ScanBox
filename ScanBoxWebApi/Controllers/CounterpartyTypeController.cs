using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CounterpartyTypeController: ControllerBase
    {
        private readonly ICrudMethodRepository<CounterpartyTypeGetDTO, CounterpartyTypePostDTO> _counterpartyTypeRepository;
        private readonly ILogger<CounterpartyTypeController> _logger;
        private readonly ITableConverter<CounterpartyTypeGetDTO> _tableConverter;

        public CounterpartyTypeController(ICrudMethodRepository<CounterpartyTypeGetDTO, CounterpartyTypePostDTO> counterpartyTypeRepository, ILogger<CounterpartyTypeController> logger, ITableConverter<CounterpartyTypeGetDTO> tableConverter)
        {
            _counterpartyTypeRepository = counterpartyTypeRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template:"add_counterparty_type" )]
        public ActionResult<int> AddCounterpartyType ([FromBody] CounterpartyTypePostDTO counterpartyTypePostDTO)
        {
            try
            {
                var result = _counterpartyTypeRepository.Create(counterpartyTypePostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a counterpartyType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_counterparty_type")]
        public ActionResult<int> PutCounterpartyType([FromBody] CounterpartyTypeGetDTO counterpartyTypeDTO)
        {
            try
            {
                var result = _counterpartyTypeRepository.Update(counterpartyTypeDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a counterpartyType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_counterparty_type")]
        public ActionResult<int> DeleteCounterpartyType([FromBody] int counterpartyTypeId)
        {
            try
            {
                var result = _counterpartyTypeRepository.Delete(counterpartyTypeId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a counterpartyType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_counterparty_types")]
        public ActionResult<IEnumerable<CounterpartyTypeGetDTO>> GetCounterpartyTypes()
        {
            try
            {
                var result = _counterpartyTypeRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of counterpartyType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_counterparty_types_csv")]
        public ActionResult<string> GetCounterpartyTypesAsCsv()
        {
            try
            {
                var list = _counterpartyTypeRepository.GetElemetsList();
                var result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of counterparty types as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
