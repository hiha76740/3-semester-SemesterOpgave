using UserService.DomainLib.Entities;

namespace UserService.ApplicationLib.Repositories;

/// <summary>
/// 
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    Task<User?> GetUserByUsernameAsync(string username);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<User?> GetUserById(UserId id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    Task<bool> UsernameExsistsAsync(string username);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task RegisterUserAsync(User user);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task SaveAsync();
}
