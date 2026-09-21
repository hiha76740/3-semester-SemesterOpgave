using BookMyHome.ContractsLib.Requests.Users;

namespace BookMyHome.Web.Services
{
    public interface IAuthService
    {
        Task<int> Login(string username, string password);

        Task<int> Register(RegisterUserRequest request);
    }
}
