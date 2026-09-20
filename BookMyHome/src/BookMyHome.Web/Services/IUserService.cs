using BookMyHome.Web.Models;

namespace BookMyHome.Web.Services
{
    public interface IUserService
    {
        Task Login();

        Task<int> Register(UserModel model);
    }
}
