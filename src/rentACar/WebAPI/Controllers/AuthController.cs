using Application.Features.Authorizations.Commands.LoginCommand;
using Application.Features.Authorizations.Commands.RegisterCommand;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            var result = await Mediator.Send(loginUserCommand);
            return result.Success ? Ok(result) : Unauthorized(result.Message);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            var result = await Mediator.Send(registerUserCommand);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
