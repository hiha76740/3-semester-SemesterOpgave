using Microsoft.EntityFrameworkCore;
using UserService.ApplicationLib.Repositories;
using UserService.DomainLib.Entities;
using UserService.InfrastructureLib.Persistence;

namespace UserService.InfrastructureLib.Repositories;

public class UserRepository(UserDbContext db) : IUserRepository
{
    Task<User?> IUserRepository.GetUserByUsernameAsync(string username)
    {
        return db.Users.FirstOrDefaultAsync(u => u.Username == username);

    }

    async Task IUserRepository.RegisterUserAsync(User user)
    {
        await db.AddAsync(user);
    }

    async Task IUserRepository.SaveAsync()
    {
        await db.SaveChangesAsync();
    }

    Task<bool> IUserRepository.UsernameExsistsAsync(string username)
    {
        return db.Users.AnyAsync(u => u.Username == username);
    }
}
