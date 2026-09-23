using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Authentication;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IAuthService
    {
        Task<int> Login(string username, string password);

        Task<int> Register(RegisterUserRequest request);

        Task<AuthUserResponse> GetAuthUserAsync();
    }
}
