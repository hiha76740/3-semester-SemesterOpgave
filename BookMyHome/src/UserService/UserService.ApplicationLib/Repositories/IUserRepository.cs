using UserService.DomainLib.Entities;

namespace UserService.ApplicationLib.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameAsync(string username);

    Task<bool> UsernameExsistsAsync(string username);

    Task RegisterUserAsync(User user);

    Task SaveAsync();
}
