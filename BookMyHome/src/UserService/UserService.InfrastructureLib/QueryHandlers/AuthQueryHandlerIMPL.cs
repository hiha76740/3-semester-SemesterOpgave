using Microsoft.EntityFrameworkCore;
using UserService.DomainLib.Entities;
using UserService.FacadeLib.Queries.DTOs;
using UserService.FacadeLib.Queries.Interfaces;
using UserService.InfrastructureLib.Persistence;

namespace UserService.InfrastructureLib.QueryHandlers;

public class AuthQueryHandlerIMPL(UserDbContext db) : IAuthQueries
{
    async Task<AuthUserDto?> IAuthQueries.GetCurrentUserInfo(Guid id)
    {
        var userId = new UserId(id);

        return await db.Users.Where(u => u.Id == userId)
            .Select(u => new AuthUserDto(
                u.Id.Value,
                u.Username,
                u.FirstName,
                u.LastName
                ))
            .FirstOrDefaultAsync();
    }
}
