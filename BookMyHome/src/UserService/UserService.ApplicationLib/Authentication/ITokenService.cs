using System.Security.Claims;
using UserService.DomainLib.Entities;

namespace UserService.ApplicationLib.Authentication;
/// <summary>
/// 
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    string CreateToken(User user);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="expiredAccessToken"></param>
    /// <returns></returns>
    ClaimsPrincipal GetPrincipalFromExpiredToken(string expiredAccessToken);
}
