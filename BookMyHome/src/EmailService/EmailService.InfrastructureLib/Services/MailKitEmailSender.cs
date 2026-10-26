using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace EmailService.InfrastructureLib.Services;

public class MailKitEmailSender(IConfiguration appsettings, ILogger<MailKitEmailSender> logger) : IEmailSenderService
{
    async Task IEmailSenderService.SendAsync(SendEmailDto emailDto)
    {
        try
        {
            logger.LogInformation("Creating message with subject {subject} and to recipeient {recipeitentMail}", emailDto.Subject, emailDto.Email);

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("BookMyHome", "NoReply@BookMyHome.Test"));
            message.To.Add(new MailboxAddress(emailDto.Name,emailDto.Email));
            message.Subject = emailDto.Subject;
            message.Body = new TextPart("plain")
            {
                Text = emailDto.Body
            };

            using var client = new SmtpClient();

            var smtpHost = appsettings.GetValue<string>("SMTP:Host") ?? throw new InvalidOperationException("SMTP Host is missing");
            var smtpPort = appsettings.GetValue<int>("SMTP:Port");

            logger.LogInformation("Connecting to SMTP server {smtpHost} on port {smtpPort}", smtpHost, smtpPort);

            await client.ConnectAsync(
                smtpHost,
                smtpPort,
                SecureSocketOptions.None
                );

            logger.LogInformation("Sending email");

            await client.SendAsync(message);

            logger.LogInformation("Email send successfully, disconnecting from server");

            await client.DisconnectAsync(true);

            logger.LogInformation("Disconnected successfully");
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
