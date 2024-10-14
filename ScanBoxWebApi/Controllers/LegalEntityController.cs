using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Repository;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LegalEntityController : ControllerBase
    {
        public readonly ICrudMethodRepository<LegalEntityGetDTO, LegalEntityPostDTO> _legalEntityRepository;
        public readonly ILogger<LegalEntityController> _logger;

        public LegalEntityController(ICrudMethodRepository<LegalEntityGetDTO, LegalEntityPostDTO> legalEntityRepository, ILogger<LegalEntityController> logger)
        {
            _legalEntityRepository = legalEntityRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_legal_entity")]
        public ActionResult<int> AddLegalEntity(LegalEntityPostDTO legalEntityPostDTO)
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

        [HttpPut(template: "put_legal_entity")]
        public ActionResult<int> PutLegalEntity(LegalEntityGetDTO legalEntityDTO)
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

        [HttpDelete(template: "delete_legal_entity")]
        public ActionResult<int> DeleteLegalEntity(int legalEntityId)
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

        [HttpGet(template: "get_legal_entity")]
        public ActionResult<IEnumerable<LegalEntityGetDTO>> GetLegalEntities()
        {
            try
            {
                var result = _legalEntityRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of LegalEnttity: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
