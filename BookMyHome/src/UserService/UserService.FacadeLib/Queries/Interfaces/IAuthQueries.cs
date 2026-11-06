using UserService.FacadeLib.Queries.DTOs;

namespace UserService.FacadeLib.Queries.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IAuthQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AuthUserDto?> GetCurrentUserInfo(Guid id);
}
