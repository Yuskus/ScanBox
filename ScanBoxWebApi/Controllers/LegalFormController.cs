using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Repository;

namespace ScanBoxWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LegalFormController : ControllerBase
    {
        public readonly ICrudMethodRepository<LegalFormGetDTO, LegalFormPostDTO> _legalFormRepository;
        public readonly ILogger<LegalFormController> _logger;

        public LegalFormController(ICrudMethodRepository<LegalFormGetDTO, LegalFormPostDTO> legalFormRepository, ILogger<LegalFormController> logger)
        {
            _legalFormRepository = legalFormRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_legal_form")]
        public ActionResult<int> AddLegalForm(LegalFormPostDTO legalFormPostDTO)
        {
            try
            {
                var result = _legalFormRepository.Create(legalFormPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a LegalForm: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_legal_form")]
        public ActionResult<int> PutLegalForm(LegalFormGetDTO legalFormDTO)
        {
            try
            {
                var result = _legalFormRepository.Update(legalFormDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a LegalForm: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "delete_legal_form")]
        public ActionResult<int> DeleteLegalForm(int legalFormId)
        {
            try
            {
                var result = _legalFormRepository.Delete(legalFormId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a LegalForm: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet(template: "get_legal_form")]
        public ActionResult<IEnumerable<LegalFormGetDTO>> GetLegalForms()
        {
            try
            {
                var result = _legalFormRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of LegalForms: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }

}
