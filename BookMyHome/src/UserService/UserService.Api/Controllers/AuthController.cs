using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Users;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Mapper;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IRegisterUserHandler register, ILoginHandler login, IRefreshTokensHandler refreshToken) : ControllerBase
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
        public async Task<ActionResult<TokenResponse>> Login(LoginRequest request)
        {
            try
            {
                var token = await login.HandleAsync(request.AsLoginCommand());

                if (token == null)
                    return BadRequest("Invalid username or password");

                return Ok(token.AsTokenResponse());
            }
            catch (Exception ex) 
            {

                return BadRequest(ex);
            }
        }

        [HttpPost("Refresh-token")]
        public async Task<ActionResult<TokenResponse>> Refresh(RefreshTokenRequest request)
        {
            try
            {
                var result = await refreshToken.HandleAsync(request.AsTokenCommand());

                if (result == null || result.AccessToken == null || result.RefreshToken == null)
                    return Unauthorized("Invalid refresh token");

                return Ok(result.AsTokenResponse());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
