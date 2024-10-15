using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class BuyerController : ControllerBase
    {
        private readonly ICrudMethodRepository<BuyerGetDTO, BuyerPostDTO> _buyerRepository;
        private readonly ILogger<BuyerController> _logger;

        public BuyerController(ICrudMethodRepository<BuyerGetDTO, BuyerPostDTO> buyerRepository, ILogger<BuyerController> logger)
        {
            _buyerRepository = buyerRepository;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_buyer")]
        public ActionResult<int> AddBuyer([FromBody] BuyerPostDTO buyerPostDTO)
        {
            try
            {
                var result = _buyerRepository.Create(buyerPostDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a buyer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "put_buyer")]
        public ActionResult<int> PutBuyer([FromBody] BuyerGetDTO buyerDTO)
        {
            try
            {
                var result = _buyerRepository.Update(buyerDTO);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when updating a buyer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_buyer")]
        public ActionResult<int> DeleteBuyer([FromBody] int buyerDtoId)
        {
            try
            {
                var result = _buyerRepository.Delete(buyerDtoId);
                if (result == -1)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when deleting a buyer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_buyers")]
        public ActionResult<IEnumerable<BuyerGetDTO>> GetBuyers()
        {
            try
            {
                var result = _buyerRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of buyers: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
