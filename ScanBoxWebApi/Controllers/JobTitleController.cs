using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    public class JobTitleController : ControllerBase
    {
        public readonly ICrudMethodRepository<JobTitleGetDTO, JobTitlePostDTO> _jobTitleRepository;
        public readonly ILogger<JobTitleController> _logger;
        public JobTitleController(ICrudMethodRepository<JobTitleGetDTO, JobTitlePostDTO>  jobtiTleRepository, ILogger<JobTitleController> logger)
        {
            _jobTitleRepository = jobtiTleRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_job_title")]
        public ActionResult<int> AddJobTitle(JobTitlePostDTO jobTitlePostDTO)
        {
            try
            {
                var result = _jobTitleRepository.Create(jobTitlePostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a JobTitle: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_job_title")]
        public ActionResult<int> PutJobTitle(JobTitleGetDTO jobTitleDTO)
        {
            try
            {
                var result = _jobTitleRepository.Update(jobTitleDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a JobTitle: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "delete_job_title")]
        public ActionResult<int> DeleteJobTitle(int jobTitleId)
        {
            try
            {
                var result = _jobTitleRepository.Delete(jobTitleId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a JobTitle: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet(template: "get_job_title")]
        public ActionResult<IEnumerable<JobTitleGetDTO>> GetJobTitles()
        {
            try
            {
                var result = _jobTitleRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of JobTitle: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
