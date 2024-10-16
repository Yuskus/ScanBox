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
        public IndividualController(ICrudMethodRepository<IndividualGetDTO, IndividualPostDTO> individualRepository, ILogger<IndividualController> logger)
        {
            _individualRepository = individualRepository;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_individual")]
        public ActionResult<int> AddIndividual([FromBody] IndividualPostDTO individualPostDTO)
        {
            try
            {
                var result = _individualRepository.Create(individualPostDTO);
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
        public ActionResult<int> PutIndividual([FromBody] IndividualGetDTO individualDTO)
        {
            try
            {
                var result = _individualRepository.Update(individualDTO);
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
        public ActionResult<int> DeleteIndividual([FromBody] int individualId)
        {
            try
            {
                var result = _individualRepository.Delete(individualId);
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
        public ActionResult<IEnumerable<IndividualGetDTO>> GetIndividuals()
        {
            try
            {
                var result = _individualRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of Individual: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
