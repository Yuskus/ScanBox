using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegalEntityController : ControllerBase
    {
        private readonly ICrudMethodRepository<LegalEntityGetDTO, LegalEntityPostDTO> _legalEntityRepository;
        private readonly ILogger<LegalEntityController> _logger;

        public LegalEntityController(ICrudMethodRepository<LegalEntityGetDTO, LegalEntityPostDTO> legalEntityRepository, ILogger<LegalEntityController> logger)
        {
            _legalEntityRepository = legalEntityRepository;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_legal_entity")]
        public ActionResult<int> AddLegalEntity([FromBody] LegalEntityPostDTO legalEntityPostDTO)
        {
            try
            {
                var result = _legalEntityRepository.Create(legalEntityPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a LegalEntity: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_legal_entity")]
        public ActionResult<int> PutLegalEntity([FromBody] LegalEntityGetDTO legalEntityDTO)
        {
            try
            {
                var result = _legalEntityRepository.Update(legalEntityDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a LegalEntity: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_legal_entity")]
        public ActionResult<int> DeleteLegalEntity([FromBody] int legalEntityId)
        {
            try
            {
                var result = _legalEntityRepository.Delete(legalEntityId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a LegalEntity: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_legal_entities")]
        public ActionResult<IEnumerable<LegalEntityGetDTO>> GetLegalEntities()
        {
            try
            {
                var result = _legalEntityRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of LegalEntity: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
