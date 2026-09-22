using UserService.FacadeLib.Queries.DTOs;

namespace UserService.FacadeLib.Queries.Interfaces;

public interface IAuthQueries
{
    Task<AuthUserDto?> GetCurrentUserInfo(Guid id);
}
