using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobTitleController : ControllerBase
    {
        private readonly ICrudMethodRepository<JobTitleGetDTO, JobTitlePostDTO> _jobTitleRepository;
        private readonly ILogger<JobTitleController> _logger;
        private readonly ITableConverter<JobTitleGetDTO> _tableConverter;

        public JobTitleController(ICrudMethodRepository<JobTitleGetDTO, JobTitlePostDTO>  jobtiTleRepository, 
                                  ILogger<JobTitleController> logger, 
                                  ITableConverter<JobTitleGetDTO> tableConverter)
        {
            _jobTitleRepository = jobtiTleRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_job_title")]
        public async Task<ActionResult<int>> AddJobTitle([FromBody] JobTitlePostDTO jobTitlePostDTO)
        {
            try
            {
                var result = await _jobTitleRepository.Create(jobTitlePostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a JobTitle: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_job_title")]
        public async Task<ActionResult<int>> PutJobTitle([FromBody] JobTitleGetDTO jobTitleDTO)
        {
            try
            {
                var result = await _jobTitleRepository.Update(jobTitleDTO);
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

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_job_title")]
        public async Task<ActionResult<int>> DeleteJobTitle([FromBody] int jobTitleId)
        {
            try
            {
                var result = await _jobTitleRepository.Delete(jobTitleId);
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

        [Authorize]
        [HttpGet(template: "get_job_titles")]
        public async Task<ActionResult<IEnumerable<JobTitleGetDTO>>> GetJobTitles()
        {
            try
            {
                var result = await _jobTitleRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of JobTitle: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_job_titles_csv")]
        public async Task<ActionResult<string>> GetJobTitlesAsCsv()
        {
            try
            {
                var list = await _jobTitleRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of job titles as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
