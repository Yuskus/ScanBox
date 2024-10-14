using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    public class DocumentTypeController : ControllerBase
    {
        public readonly ICrudMethodRepository<DocumentTypeGetDTO, DocumentTypePostDTO> _documentTypeRepository;
        public readonly ILogger<DocumentTypeController> _logger;
        public DocumentTypeController(ICrudMethodRepository<DocumentTypeGetDTO, DocumentTypePostDTO> documentTypeRepository, ILogger<DocumentTypeController> logger)
        {
            _documentTypeRepository = documentTypeRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_document_type")]
        public ActionResult<int> AddDocumentType(DocumentTypePostDTO documentTypePostDTO)
        {
            try
            {
                var result = _documentTypeRepository.Create(documentTypePostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a DocumentType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_document_type")]
        public ActionResult<int> PutDocumentType(DocumentTypeGetDTO documentTypeDTO)
        {
            try
            {
                var result = _documentTypeRepository.Update(documentTypeDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a DocumentType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "delete_document_type")]
        public ActionResult<int> DeleteDocumentType(int documentTypeId)
        {
            try
            {
                var result = _documentTypeRepository.Delete(documentTypeId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a DocumentType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet(template: "get_document_type")]
        public ActionResult<IEnumerable<DocumentTypeGetDTO>> GetDocumentsType()
        {
            try
            {
                var result = _documentTypeRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of DocumentType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
