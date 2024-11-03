using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ITableConverter<MovementHistoryGetDTO> _tableConverter;

        public MovementHistoryController(ICrudMethodRepository<MovementHistoryGetDTO, MovementHistoryPostDTO> movementHistoryRepository, ILogger<MovementHistoryController> logger, ITableConverter<MovementHistoryGetDTO> tableConverter)
        {
            _movementHistoryRepository = movementHistoryRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize]
        [HttpPost(template: "add_movement_history")]
        public ActionResult<int> AddMovement([FromBody] MovementHistoryPostDTO movementHistoryPostDTO)
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

        [Authorize]
        [HttpPut(template: "put_movement_history")]
        public ActionResult<int> PutMovement([FromBody] MovementHistoryGetDTO movementHistoryDTO)
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

        [Authorize]
        [HttpDelete(template: "delete_movement_history")]
        public ActionResult<int> DeleteMovement([FromBody] int movementHistoryId)
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

        [Authorize]
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

        [Authorize]
        [HttpGet(template: "get_movement_history_csv")]
        public ActionResult<string> GetMovementHistoryAsCsv()
        {
            try
            {
                var list = _movementHistoryRepository.GetElemetsList();
                var result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of movement history as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
