using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;

namespace EmailService.ApplicationLib.Handlers;

public class SendUserConfirmationHandler(IEmailSenderService emailSender, ILogger<SendUserConfirmationHandler> logger) : ISendUserConfirmationHandler
{
    Task ISendUserConfirmationHandler.HandleAsync(SendUserConfirmationCommand command)
    {
        try
        {
            logger.LogInformation("Starting to send user confirmation for user: {username}", command.Username);

            var subject = $"Bekræftelse for bruger oprettelse";
            var name = $"{command.Firstname} {command.Lastname}";

            var body = $"""
            Hej {name}

            Velkommen til Book My Home.

            Du er oprettet med følgende brugernavn:
            {command.Username}

            Vi håber du nemt finder dit næste ophold.
            """;

            logger.LogInformation("Sending user confirmation for user: {username}", command.Username);

            var emailDto = new SendEmailDto(name, command.Email, subject, body);

            return emailSender.SendAsync(emailDto);
        }
        catch (Exception ex)
        {
            logger.LogError("Exception error: {error}", ex.Message);

            if (ex.InnerException != null)
                logger.LogError("InnerException error: {error}", ex.InnerException.Message);

            throw;
        }
    }
}
