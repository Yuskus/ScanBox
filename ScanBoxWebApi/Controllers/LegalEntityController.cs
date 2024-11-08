﻿using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
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
        private readonly ITableConverter<LegalEntityGetDTO> _tableConverter;

        public LegalEntityController(ICrudMethodRepository<LegalEntityGetDTO, LegalEntityPostDTO> legalEntityRepository, 
                                     ILogger<LegalEntityController> logger, 
                                     ITableConverter<LegalEntityGetDTO> tableConverter)
        {
            _legalEntityRepository = legalEntityRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_legal_entity")]
        public async Task<ActionResult<int>> AddLegalEntity([FromBody] LegalEntityPostDTO legalEntityPostDTO)
        {
            try
            {
                var result = await _legalEntityRepository.Create(legalEntityPostDTO);
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
        public async Task<ActionResult<int>> PutLegalEntity([FromBody] LegalEntityGetDTO legalEntityDTO)
        {
            try
            {
                var result = await _legalEntityRepository.Update(legalEntityDTO);
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
        public async Task<ActionResult<int>> DeleteLegalEntity([FromBody] int legalEntityId)
        {
            try
            {
                var result = await _legalEntityRepository.Delete(legalEntityId);
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
        public async Task<ActionResult<IEnumerable<LegalEntityGetDTO>>> GetLegalEntities()
        {
            try
            {
                var result = await _legalEntityRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of LegalEntity: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_legal_entities_csv")]
        public async Task<ActionResult<string>> GetLegalEntitiesAsCsv()
        {
            try
            {
                var list = await _legalEntityRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of legal entities as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
