using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
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

        [HttpPost(template: "add_individual")]
        public ActionResult<int> AddIndividual(IndividualPostDTO individualPostDTO)
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

        [HttpPut(template: "put_individual")]
        public ActionResult<int> PutIndividual(IndividualGetDTO individualDTO)
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

        [HttpDelete(template: "delete_individual")]
        public ActionResult<int> DeleteIndividual(int individualId)
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
