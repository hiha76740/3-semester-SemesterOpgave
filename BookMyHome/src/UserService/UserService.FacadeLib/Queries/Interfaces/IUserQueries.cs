using UserService.FacadeLib.Queries.DTOs;

namespace UserService.FacadeLib.Queries.Interfaces;

public interface IUserQueries
{
    IReadOnlyList<AccessRoleDto> GetAllAccessRoles();
}
