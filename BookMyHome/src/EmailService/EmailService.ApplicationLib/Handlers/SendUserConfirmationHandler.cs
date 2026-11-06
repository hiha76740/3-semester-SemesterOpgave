using System.Globalization;
using System.Text;
using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;

namespace EmailService.ApplicationLib.Handlers;

/// <summary>
/// 
/// </summary>
/// <param name="emailSender"></param>
/// <param name="logger"></param>
public class SendUserConfirmationHandler(IEmailSenderService emailSender, ILogger<SendUserConfirmationHandler> logger) : ISendUserConfirmationHandler
{
    Task ISendUserConfirmationHandler.HandleAsync(SendUserConfirmationCommand command)
    {
        try
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Starting to send user confirmation for user: {Username}", command.Username);

            var subject = $"Bekræftelse for bruger oprettelse";
            var name = $"{command.Firstname} {command.Lastname}";

            var builder = new StringBuilder();

            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<p>Hej {name}</p>");
            builder.Append("<br/>");
            builder.Append("<p>Velkommen til BookMyHome.</p>");
            builder.Append("<br/>");
            builder.Append("<p>Du er oprettet med følgende brugernavn:</p>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<h4>{command.Username}</h4>");
            builder.Append("<br/>");
            builder.Append("<p>Vi håber du nemt finder dit næste ophold.</p>");
            builder.Append("<br/>");
            builder.Append("<img src=\"{{LogoCid}}\" alt=\"BookMyHome\" width=\"200\">");

            var body = builder.ToString();

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Sending user confirmation for user: {Username}", command.Username);

            var emailDto = new SendEmailDto(name, command.Email, subject, body);

            return emailSender.SendAsync(emailDto);
        }
        catch (Exception ex)
        {

            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError("Exception error: {Error}", ex.Message);

                if (ex.InnerException != null)
                    logger.LogError("InnerException error: {Error}", ex.InnerException.Message);
            }

            throw;
        }
    }
}
