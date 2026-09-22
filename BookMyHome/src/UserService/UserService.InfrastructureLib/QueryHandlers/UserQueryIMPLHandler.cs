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
    }
}
