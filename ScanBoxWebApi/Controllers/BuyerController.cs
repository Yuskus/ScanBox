using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
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

        [HttpPost(template: "add_buyer")]
        public ActionResult<int> AddBueyr([FromBody] BuyerPostDTO buyerDTO)
        {
            try
            {
                var result = _buyerRepository.Create(buyerDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when adding a buyer: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPut(template: "put_buyer")]
        public ActionResult<int> PutBueyr([FromBody] BuyerGetDTO buyerDTO)
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

        [HttpDelete(template: "delуеу_buyer")]
        public ActionResult<int> DeleteBueyr(int buyerDtoId)
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

        [HttpGet(template: "get_buyer")]
        public ActionResult<IEnumerable<BuyerGetDTO>> GetBuyer()
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
