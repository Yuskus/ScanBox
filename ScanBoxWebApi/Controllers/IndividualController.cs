using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualController : ControllerBase
    {
        private readonly ICrudMethodRepository<IndividualGetDTO, IndividualPostDTO> _individualRepository;
        private readonly ILogger<IndividualController> _logger;
        private readonly ITableConverter<IndividualGetDTO> _tableConverter;

        public IndividualController(ICrudMethodRepository<IndividualGetDTO, IndividualPostDTO> individualRepository, 
                                    ILogger<IndividualController> logger, 
                                    ITableConverter<IndividualGetDTO> tableConverter)
        {
            _individualRepository = individualRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_individual")]
        public async Task<ActionResult<int>> AddIndividual([FromBody] IndividualPostDTO individualPostDTO)
        {
            try
            {
                var result = await _individualRepository.Create(individualPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a Individual: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_individual")]
        public async Task<ActionResult<int>> PutIndividual([FromBody] IndividualGetDTO individualDTO)
        {
            try
            {
                var result = await _individualRepository.Update(individualDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a Individual: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_individual")]
        public async Task<ActionResult<int>> DeleteIndividual([FromBody] int individualId)
        {
            try
            {
                var result = await _individualRepository.Delete(individualId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a Individual: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_individuals")]
        public async Task<ActionResult<IEnumerable<IndividualGetDTO>>> GetIndividuals()
        {
            try
            {
                var result = await _individualRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Individual: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_individuals_csv")]
        public async Task<ActionResult<string>> GetIndividualsAsCsv()
        {
            try
            {
                var list = await _individualRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of individuals as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
