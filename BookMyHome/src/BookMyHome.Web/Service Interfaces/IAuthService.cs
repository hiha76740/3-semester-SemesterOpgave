using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Authentication;

namespace BookMyHome.Web.Services
{
    public interface IAuthService
    {
        Task<int> Login(string username, string password);

        Task<int> Register(RegisterUserRequest request);

        Task<AuthUserResponse> GetAuthUserAsync();
    }
}
