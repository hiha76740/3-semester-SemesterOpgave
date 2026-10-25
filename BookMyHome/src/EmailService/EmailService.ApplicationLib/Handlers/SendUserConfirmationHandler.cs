using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;

namespace EmailService.ApplicationLib.Handlers;

public class SendUserConfirmationHandler(IEmailSenderService emailSender) : ISendUserConfirmationHandler
{
    Task ISendUserConfirmationHandler.HandleAsync(SendUserConfirmationCommand command)
    {
        var subject = $"Bekræftelse for bruger oprettelse";
        var name = $"{command.Firstname} {command.Lastname}";

        var body = $"""
            Hej {name}

            Velkommen til Book My Home.

            Du er oprettet med følgende brugernavn:
            {command.Username}

            Vi håber du nemt finder dit næste ophold.
            """;

        return emailSender.SendAsync(
            name,
            command.Email,
            subject,
            body
            );
    }
}
