using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Authentication;

namespace BookMyHome.Web.ServiceInterfaces;

/// <summary>
/// 
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<int> Login(string username, string password);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<int> Register(RegisterUserRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<AuthUserResponse> GetAuthUserAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task LogOut();
}
