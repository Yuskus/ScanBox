using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly ICrudMethodRepository<DocumentGetDTO, DocumentPostDTO> _documentRepository;
        private readonly ILogger<DocumentController> _logger;
        private readonly ITableConverter<DocumentGetDTO> _tableConverter;

        public DocumentController(ICrudMethodRepository<DocumentGetDTO, DocumentPostDTO> documentRepository, ILogger<DocumentController> logger, ITableConverter<DocumentGetDTO> tableConverter)
        {
            _documentRepository = documentRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize]
        [HttpPost(template:"add_document")]
        public ActionResult<int> AddDocument([FromBody] DocumentPostDTO documentPostDTO)
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

        [Authorize]
        [HttpPut(template: "put_document")]
        public ActionResult<int> PutDocument([FromBody] DocumentGetDTO documentDTO)
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

        [Authorize]
        [HttpDelete(template: "delete_document")]
        public ActionResult<int> DeleteDocument([FromBody] int documentId)
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

        [Authorize]
        [HttpGet(template: "get_documents")]
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

        [Authorize]
        [HttpGet(template: "get_documents_csv")]
        public ActionResult<string> GetDocumentsAsCsv()
        {
            try
            {
                var list = _documentRepository.GetElemetsList();
                var result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of documents as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
