using EmailService.FacadeLib.Commands.DTOs;

namespace EmailService.FacadeLib.Commands.Interfaces;

/// <summary>
/// 
/// </summary>
public interface ISendBookingConfirmationHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(SendBookingConfirmationCommand command);
}
