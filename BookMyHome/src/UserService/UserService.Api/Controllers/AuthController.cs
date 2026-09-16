using BookMyHome.ContractsLib.Requests.Users;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Mapper;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IRegisterUserHandler register) : ControllerBase
    {
        [HttpPost("register")]
        async public Task<ActionResult> Register(RegisterUserRequest request)
        {
            await register.Handle(request.AsCommand());

            return Ok();
        }

    }
}
