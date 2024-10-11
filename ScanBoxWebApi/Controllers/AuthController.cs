using DatabaseModel.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ITokenGenerator tokenGenerator, IUserRightsService userService) : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator = tokenGenerator;
        private readonly IUserRightsService _userService = userService;

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<string> Auth([FromBody] LoginFormDTO loginForm)
        {
            try
            {
                var userModel = _userService.Authenticate(loginForm);
                if (userModel is not null)
                {
                    var tokenString = _tokenGenerator.GetToken(userModel);
                    return Ok(tokenString);
                }
                return BadRequest("Please pass the valid Username and Password");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [Authorize]
        [HttpPost("check_any")]
        public ActionResult CheckAny()
        {
            return Ok("Hello, Someone!");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("check_admin")]
        public ActionResult CheckAdmin()
        {
            return Ok("Hello, Admin!");
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("check_user")]
        public ActionResult CheckUser()
        {
            return Ok("Hello, User!");
        }
    }
}
