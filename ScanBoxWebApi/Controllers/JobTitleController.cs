using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    public class JobTitleController : ControllerBase
    {
        public readonly ICrudMethodRepository<JobTitleGetDTO, JobTitlePostDTO> _individualRepository;
        public readonly ILogger<IndividualController> _logger;
        public JobTitleController(ICrudMethodRepository<JobTitleGetDTO, JobTitlePostDTO> individualRepository, ILogger<IndividualController> logger)
        {
            _individualRepository = individualRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_individual")]
        public ActionResult<int> AddIndividual(JobTitlePostDTO individualPostDTO)
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
        public ActionResult<int> PutIndividual(JobTitleGetDTO individualDTO)
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

        [HttpGet(template: "get_individual")]
        public ActionResult<IEnumerable<JobTitleGetDTO>> GetIndividuals()
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
