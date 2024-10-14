﻿using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementHistoryController : ControllerBase
    {
        private readonly ICrudMethodRepository<MovementHistoryGetDTO, MovementHistoryPostDTO> _movementHistoryRepository;
        private readonly ILogger<MovementHistoryController> _logger;

        public MovementHistoryController(ICrudMethodRepository<MovementHistoryGetDTO, MovementHistoryPostDTO> movementHistoryRepository, ILogger<MovementHistoryController> logger)
        {
            _movementHistoryRepository = movementHistoryRepository;
            _logger = logger;
        }

        [HttpPost(template: "add_movement_history")]
        public ActionResult<int> AddMovement(MovementHistoryPostDTO movementHistoryPostDTO)
        {
            try
            {
                var result = _movementHistoryRepository.Create(movementHistoryPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a MovementHistory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_movement_history")]
        public ActionResult<int> PutMovement(MovementHistoryGetDTO movementHistoryDTO)
        {
            try
            {
                var result = _movementHistoryRepository.Update(movementHistoryDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a MovementHistory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "delete_movement_history")]
        public ActionResult<int> DeleteMovement(int movementHistoryId)
        {
            try
            {
                var result = _movementHistoryRepository.Delete(movementHistoryId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a MovementHistory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet(template: "get_movement_history")]
        public ActionResult<IEnumerable<MovementHistoryGetDTO>> GetMovementHistory()
        {
            try
            {
                var result = _movementHistoryRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of MovementHistory: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}