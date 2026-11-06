using UserService.FacadeLib.Commands.DTOs;

namespace UserService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ILoginHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<TokenDto?> HandleAsync(LoginCommand command);
}
