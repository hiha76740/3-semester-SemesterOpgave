using BookMyHome.ContractsLib.Requests.Users;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public Task<ActionResult> Register(RegisterUserRequest request)
        {
            
        }

    }
}
