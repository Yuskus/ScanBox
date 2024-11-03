using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LegalFormController : ControllerBase
    {
        private readonly ICrudMethodRepository<LegalFormGetDTO, LegalFormPostDTO> _legalFormRepository;
        private readonly ILogger<LegalFormController> _logger;
        private readonly ITableConverter<LegalFormGetDTO> _tableConverter;

        public LegalFormController(ICrudMethodRepository<LegalFormGetDTO, LegalFormPostDTO> legalFormRepository, 
                                   ILogger<LegalFormController> logger, 
                                   ITableConverter<LegalFormGetDTO> tableConverter)
        {
            _legalFormRepository = legalFormRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_legal_form")]
        public ActionResult<int> AddLegalForm([FromBody] LegalFormPostDTO legalFormPostDTO)
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

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_legal_form")]
        public ActionResult<int> PutLegalForm([FromBody] LegalFormGetDTO legalFormDTO)
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

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_legal_form")]
        public ActionResult<int> DeleteLegalForm([FromBody] int legalFormId)
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

        [Authorize]
        [HttpGet(template: "get_legal_forms")]
        public ActionResult<IEnumerable<LegalFormGetDTO>> GetLegalForms()
        {
            try
            {
                var result = _legalFormRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of LegalForm: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_legal_forms_csv")]
        public ActionResult<string> GetLegalFormsAsCsv()
        {
            try
            {
                var list = _legalFormRepository.GetElemetsList();
                var result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of legal forms as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }

}
