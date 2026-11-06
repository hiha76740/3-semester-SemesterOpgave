using BookMyHome.ContractsLib.Events;
using EmailService.FacadeLib.Commands.DTOs;

namespace EmailService.Api.Mappers;

/// <summary>
/// 
/// </summary>
public static class UserEventMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="integrationEvent"></param>
    /// <returns></returns>
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
