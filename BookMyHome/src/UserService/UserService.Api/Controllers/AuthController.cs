using BookMyHome.ContractsLib.Requests.Users;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Mapper;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IRegisterUserHandler register, ILoginHandler login) : ControllerBase
    {
        [HttpPost("register")]
        async public Task<ActionResult> Register(RegisterUserRequest request)
        {
            try
            {
                await register.Handle(request.AsRegisterCommand());

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginRequest request)
        {
            try
            {
                var token = await login.HandleAsync(request.AsLoginCommand());

                if (token == null)
                    return BadRequest("Invalid username or password");

                return Ok(token);
            }
            catch (Exception ex) 
            {

                return BadRequest(ex);
            }
        }
    }
}
