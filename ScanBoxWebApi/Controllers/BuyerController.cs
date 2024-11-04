using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
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
        private readonly ITableConverter<BuyerGetDTO> _tableConverter;

        public BuyerController(ICrudMethodRepository<BuyerGetDTO, BuyerPostDTO> buyerRepository, 
                               ILogger<BuyerController> logger, 
                               ITableConverter<BuyerGetDTO> tableConverter)
        {
            _buyerRepository = buyerRepository;
            _logger = logger;
            _tableConverter = tableConverter;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "add_buyer")]
        public async Task<ActionResult<int>> AddBuyer([FromBody] BuyerPostDTO buyerPostDTO)
        {
            try
            {
                var result = await _buyerRepository.Create(buyerPostDTO);
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
        public async Task<ActionResult<int>> PutBuyer([FromBody] BuyerGetDTO buyerDTO)
        {
            try
            {
                var result = await _buyerRepository.Update(buyerDTO);
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
        public async Task<ActionResult<int>> DeleteBuyer([FromBody] int buyerDtoId)
        {
            try
            {
                var result = await _buyerRepository.Delete(buyerDtoId);
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
        public async Task<ActionResult<IEnumerable<BuyerGetDTO>>> GetBuyers()
        {
            try
            {
                var result = await _buyerRepository.GetElemetsList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of buyers: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "get_buyers_csv")]
        public async Task<ActionResult<string>> GetBuyersAsCsv()
        {
            try
            {
                var list = await _buyerRepository.GetElemetsList();
                string result = _tableConverter.Convert(list);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when requesting a list of _ as csv: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
