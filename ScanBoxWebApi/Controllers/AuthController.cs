using ScanBoxWebApi.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ITokenGenerator tokenGenerator, IUserRightsService userService, ILogger<AuthController> logger) : ControllerBase
    {
        private readonly ITokenGenerator _tokenGenerator = tokenGenerator;
        private readonly IUserRightsService _userService = userService;
        private readonly ILogger<AuthController> _logger = logger;

        [AllowAnonymous]
        [HttpPost(template: "login")]
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
                _logger.LogError(ex, "Error when trying to authenticate: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpGet(template: "check_any")]
        public ActionResult<string> CheckAny()
        {
            return Ok("Hello, Someone!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet(template: "check_admin")]
        public ActionResult<string> CheckAdmin()
        {
            return Ok("Hello, Admin!");
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet(template: "check_user")]
        public ActionResult<string> CheckUser()
        {
            return Ok("Hello, User!");
        }
    }
}
