using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Users;

namespace BookMyHome.Web.Services
{
    public interface IUserService
    {
        Task Login(string username, string password);

        Task<int> Register(RegisterUserRequest request);
    }
}
