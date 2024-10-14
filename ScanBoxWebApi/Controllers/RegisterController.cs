using DatabaseModel.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController(IRegister register, ILogger logger) : ControllerBase
    {
        private readonly IRegister _register = register;
        private readonly ILogger _logger = logger;

        [Authorize(Roles = "Admin")]
        [HttpPost(template: "register_user")]
        public ActionResult RegisterUser([FromBody] RegisterFormDTO registerForm)
        {
            try
            {
                int result = _register.RegisterUser(registerForm);
                if (result < 0) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to register an user: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut(template: "update_user_role")]
        public ActionResult UpdateUserRole([FromBody] UserRightsDTO UserDTO)
        {
            try
            {
                int result = _register.UpdateRoleUser(UserDTO);
                if (result < 0) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to update an user: {Message}", ex.Message);
                return StatusCode(500);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete(template: "delete_user")]
        public ActionResult DeleteUser([FromBody] string name)
        {
            try
            {
                int result = _register.DeleteUser(name);
                if (result < 0) return BadRequest(result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error when trying to delete an user: {Message}", ex.Message);
                return StatusCode(500);
            }
        }
    }
}
