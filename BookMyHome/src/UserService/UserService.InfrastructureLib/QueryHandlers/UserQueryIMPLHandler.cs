using Microsoft.EntityFrameworkCore;
using UserService.DomainLib.Entities;
using UserService.DomainLib.Enums;
using UserService.FacadeLib.Queries.DTOs;
using UserService.FacadeLib.Queries.Interfaces;
using UserService.InfrastructureLib.Persistence;

namespace UserService.InfrastructureLib.QueryHandlers
{
    internal class UserQueryIMPLHandler(UserDbContext db) : IUserQueries
    {
        IReadOnlyList<AccessRoleDto> IUserQueries.GetAllAccessRoles()
        {
            return Enum.GetValues<AccessRoles>()
                .Select(r => new AccessRoleDto(r.ToString())).ToList();
        }

        async Task<UserDto?> IUserQueries.GetByIdAsync(Guid id)
        {
            var userId = new UserId(id);

            return await db.Users
                .Where(u => u.Id == userId)
                .Select(u => new UserDto(
                    u.Id.Value,
                    u.FirstName,
                    u.LastName,
                    u.Birthdate,
                    u.Address.Street,
                    u.Address.PostalCode,
                    u.Address.City,
                    u.PhoneNumber.Number,
                    u.Email.EmailAddress,
                    u.Username
                    ))
                .FirstOrDefaultAsync();
                
        }
    }
}
