using DatabaseModel.DTO.GetDTO;
using DatabaseModel.DTO.PostDTO;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyerController(ICrudMethodRepository<BuyerGetDTO, BuyerPostDTO> buyerRepository) : ControllerBase
    {
        private readonly ICrudMethodRepository<BuyerGetDTO, BuyerPostDTO> _buyerRepository = buyerRepository;

        [HttpPost(template: "add_bueyr")]
        public ActionResult AddBueyr(BuyerPostDTO buyerDTO)
        {
            var result = _buyerRepository.Create(buyerDTO);
            return Ok(result);
        }
    }
}
