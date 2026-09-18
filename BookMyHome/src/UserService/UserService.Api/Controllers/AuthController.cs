using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Api.Mapper;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(IRegisterUserHandler register, ILoginHandler login, IRefreshTokensHandler refreshToken) : ControllerBase
    {

        [EndpointSummary("This endpoint will register a user")]
        [EndpointDescription("Register a user when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "User was registered succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error doing registration of user")]
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

        [EndpointSummary("This endpoint will log in a user")]
        [EndpointDescription("Logs in a user when username and password is correct")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "User was logged in succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error doing log in")]
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

        [Authorize]
        [EndpointSummary("This endpoint will create a new refresh token")]
        [EndpointDescription("Creates a new refresh token when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Refresh token was created succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error doing creation of refresh token")]
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
