using EmailService.FacadeLib.Commands.DTOs;

namespace EmailService.FacadeLib.Commands.Interfaces
{
    public interface ISendUserConfirmationHandler
    {
        Task HandleAsync(SendUserConfirmationCommand command);
    }
}
