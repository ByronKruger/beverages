using Coffeeg.Dtos.User;
using Coffeeg.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coffeeg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserManagementService Service) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserResponse>> RegisterUser(RegisterUser user)
        {
            var result = await Service.CreateUserAsync(user);

            if (!result.IsSuccess) return BadRequest("Could not register");

            return Ok(result.Value);
        }

        [HttpPost("login")]
        public async Task<ActionResult<LogInUserResponse>> Login(LogInUser user)
        {
            var result = await Service.CheckUserPasswordAsync(user);

            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.ErrorMessage);
        }
    }
}
