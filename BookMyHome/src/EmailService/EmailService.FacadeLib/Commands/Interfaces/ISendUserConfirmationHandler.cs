using EmailService.FacadeLib.Commands.DTOs;

namespace EmailService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ISendUserConfirmationHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(SendUserConfirmationCommand command);
}
