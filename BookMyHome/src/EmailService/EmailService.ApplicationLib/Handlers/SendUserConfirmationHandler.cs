using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text;

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

            StringBuilder builder = new StringBuilder();

            builder.Append($"<p>Hej {name}</p>");
            builder.Append("<br/>");
            builder.Append("<p>Velkommen til BookMyHome.</p>");
            builder.Append("<br/>");
            builder.Append("<p>Du er oprettet med følgende brugernavn:</p>");
            builder.Append($"<h4>{command.Username}</h4>");
            builder.Append("<br/>");
            builder.Append("<p>Vi håber du nemt finder dit næste ophold.</p>");
            builder.Append("<br/>");
            builder.Append("<img src=\"{{LogoCid}}\" alt=\"BookMyHome\" width=\"200\">");

            var body = builder.ToString();

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
