using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Repository;
using System.Data;

namespace ScanBoxWebApi.Controllers
{

    [ApiController]
    [Route ("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        public readonly ICrudMethodRepository<DocumentGetDTO, DocumentPostDTO> _documentRepository;
        public readonly ILogger<DocumentController> _logger;
        public DocumentController(ICrudMethodRepository<DocumentGetDTO, DocumentPostDTO> documentRepository, ILogger<DocumentController> logger)
        {
            _documentRepository = documentRepository;
            _logger = logger;
        }

        [HttpPost(template:"add_document")]
        public ActionResult<int>AddDocument(DocumentPostDTO documentPostDTO)
        {
            try
            {
                var result = _documentRepository.Create(documentPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a document: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_document")]
        public ActionResult<int> PutDocument(DocumentGetDTO documentDTO)
        {
            try
            {
                var result = _documentRepository.Update(documentDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a document: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "delete_document")]
        public ActionResult<int> DeleteDocument(int documentId)
        {
            try
            {
                var result = _documentRepository.Delete(documentId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a document: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet(template: "get_document")]
        public ActionResult<IEnumerable<DocumentGetDTO>> GetDocuments()
        {
            try
            {
                var result = _documentRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of documents: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
