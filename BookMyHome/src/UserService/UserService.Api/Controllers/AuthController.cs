using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserService.Api.Mapper;
using UserService.Api.Services;
using UserService.FacadeLib.Commands.Interfaces;
using UserService.FacadeLib.Queries.Interfaces;

namespace UserService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController(
        IRegisterUserHandler register,
        ILoginHandler login,
        IRefreshTokensHandler refresh,
        ICookieService cookieService,
        IAuthQueries authQueries
        ) : ControllerBase
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

                return BadRequest(ex.Message);
            }
        }

        [EndpointSummary("This endpoint will log in a user")]
        [EndpointDescription("Logs in a user when username and password is correct")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "User was logged in succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error doing log in")]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            try
            {
                var token = await login.HandleAsync(request.AsLoginCommand());

                if (token == null)
                    return BadRequest("Invalid username or password");

                cookieService.SetTokenInsideCookie(token, HttpContext);

                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }



        [EndpointSummary("This endpoint will create a new refresh token")]
        [EndpointDescription("Creates a new refresh token when all required info is given")]
        [ProducesResponseType(StatusCodes.Status200OK, Description = "Refresh token was created succesfully")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Description = "Error doing creation of refresh token")]
        [HttpPost("Refresh-token")]
        public async Task<ActionResult> Refresh()
        {
            try
            {
                HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
                HttpContext.Request.Cookies.TryGetValue("accessToken", out var expiredAccessToken);

                if (refreshToken == null || expiredAccessToken == null)
                    return BadRequest("Invalid request");

                var request = new RefreshTokenRequest(expiredAccessToken, refreshToken);

                var result = await refresh.HandleAsync(request.AsTokenCommand());

                if (result == null || result.AccessToken == null || result.RefreshToken == null)
                    return Unauthorized("Invalid refresh token");

                cookieService.SetTokenInsideCookie(result, HttpContext);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [Authorize]
        [HttpGet("Me")]
        public async Task<ActionResult<AuthUserResponse>> GetCurrentUserInfo()
        {
            try
            {
                var userId = GetCurrentUserId();

                if (userId == null)
                    return BadRequest("Invalid request");

                var dto = await authQueries.GetCurrentUserInfo(userId.Value);

                if (dto == null)
                    return NotFound("user not found");

                return Ok(dto.AsAuthUserReponse());

            }
            catch (Exception)
            {

                throw;
            }
        }

        //TODO: move this to shared folder and call in all API's
        private Guid? GetCurrentUserId()
        {
            var stringUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var idIsValid = Guid.TryParse(stringUserId, out Guid id);

            if (idIsValid == false)
                return null;

            return id;
        }
    }
}
