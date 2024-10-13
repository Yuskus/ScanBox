﻿using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Repository;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class CounterpartyTypeController: ControllerBase
    {
        public readonly ICrudMethodRepository<CounterpartyTypeGetDTO, CounterpartyTypePostDTO> _counterpartyTypeRepository;
        public readonly ILogger<CounterpartyTypeController> _logger;

        public CounterpartyTypeController(ICrudMethodRepository<CounterpartyTypeGetDTO, CounterpartyTypePostDTO> counterpartyTypeRepository, ILogger<CounterpartyTypeController> logger)
        {
            _counterpartyTypeRepository = counterpartyTypeRepository;
            _logger = logger;
        }

        [HttpPost(template:"add_counterparty_type" )]
        public ActionResult<int> AddCounterpartyType (CounterpartyTypePostDTO counterpartyTypeDTO)
        {
            try
            {
                var result = _counterpartyTypeRepository.Create(counterpartyTypeDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a counterpartyType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_counterparty_type")]
        public ActionResult<int> PutCounterpartyType(CounterpartyTypeGetDTO counterpartyTypeDTO)
        {
            try
            {
                var result = _counterpartyTypeRepository.Update(counterpartyTypeDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a counterpartyType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "delete_counterparty_type")]
        public ActionResult<int> DeleteCounterpartyType(int counterpartyTypeId)
        {
            try
            {
                var result = _counterpartyTypeRepository.Delete(counterpartyTypeId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a counterpartyType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet(template: "get_counterparty_type")]
        public ActionResult<IEnumerable<CounterpartyTypeGetDTO>> GetCounterpartyType()
        {
            try
            {
                var result = _counterpartyTypeRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of counterpartyType: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}