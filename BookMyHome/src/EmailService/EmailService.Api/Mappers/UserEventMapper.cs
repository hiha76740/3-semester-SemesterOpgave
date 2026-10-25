using BookMyHome.ContractsLib.Events;
using EmailService.FacadeLib.Commands.DTOs;

namespace EmailService.Api.Mappers
{
    public static class UserEventMapper
    {
        public static SendUserConfirmationCommand AsUserConfirmationCommand(this UserRegisteredIntegrationEvent integrationEvent)
        {
            var output = new SendUserConfirmationCommand(
                integrationEvent.FirstName,
                integrationEvent.LastName,
                integrationEvent.Email,
                integrationEvent.Username
                );

            return output;
        }
    }
}
