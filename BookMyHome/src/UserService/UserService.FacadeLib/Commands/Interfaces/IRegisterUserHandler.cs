using UserService.FacadeLib.Commands.DTOs;

namespace UserService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IRegisterUserHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task Handle(RegisterUserCommand command);
}
