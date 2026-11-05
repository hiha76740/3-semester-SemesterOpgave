using EmailService.FacadeLib.Commands.DTOs;

namespace EmailService.FacadeLib.Commands.Interfaces;

public interface ISendBookingConfirmationHandler
{
    Task HandleAsync(SendBookingConfirmationCommand command);
}
