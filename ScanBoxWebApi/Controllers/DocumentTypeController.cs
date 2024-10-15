﻿using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly ICrudMethodRepository<DocumentTypeGetDTO, DocumentTypePostDTO> _documentTypeRepository;
        private readonly ILogger<DocumentTypeController> _logger;
        public DocumentTypeController(ICrudMethodRepository<DocumentTypeGetDTO, DocumentTypePostDTO> documentTypeRepository, ILogger<DocumentTypeController> logger)
        {
            _documentTypeRepository = documentTypeRepository;
            _logger = logger;
        }

        [Authorize]
        [HttpPost(template: "add_document_type")]
        public ActionResult<int> AddDocumentType([FromBody] DocumentTypePostDTO documentTypePostDTO)
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

        [Authorize]
        [HttpPut(template: "put_document_type")]
        public ActionResult<int> PutDocumentType([FromBody] DocumentTypeGetDTO documentTypeDTO)
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

        [Authorize]
        [HttpDelete(template: "delete_document_type")]
        public ActionResult<int> DeleteDocumentType([FromBody] int documentTypeId)
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

        [Authorize]
        [HttpGet(template: "get_documents_types")]
        public ActionResult<IEnumerable<DocumentTypeGetDTO>> GetDocumentsTypes()
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
