using DatabaseModel.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScanBoxWebApi.Abstractions;

namespace ScanBoxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController(IRegister register) : ControllerBase
    {
        private readonly IRegister _register = register;

        [Authorize(Roles = "Admin")]
        [HttpPost("register_user")]
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
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("update_user_role")]
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
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("delete_user")]
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
                return StatusCode(500, ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
