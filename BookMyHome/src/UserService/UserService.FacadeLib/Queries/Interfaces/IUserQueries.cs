using UserService.FacadeLib.Queries.DTOs;

namespace UserService.FacadeLib.Queries.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IUserQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<AccessRoleDto> GetAllAccessRoles();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserDto?> GetByIdAsync(Guid id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> CheckIfExistsAsync(Guid id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserEmailItemDto?> GetUserEmailItemAsync(Guid id);
}
