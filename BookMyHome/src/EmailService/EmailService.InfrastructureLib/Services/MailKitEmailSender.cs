using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using MimeKit.Utils;

namespace EmailService.InfrastructureLib.Services;

/// <summary>
/// 
/// </summary>
/// <param name="appsettings"></param>
/// <param name="logger"></param>
public class MailKitEmailSender(IConfiguration appsettings, ILogger<MailKitEmailSender> logger) : IEmailSenderService
{
    async Task IEmailSenderService.SendAsync(SendEmailDto emailDto)
    {
        try
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Creating message with subject {Subject} and to recipeient {RecipeitentMail}", emailDto.Subject, emailDto.Email);

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("BookMyHome", "NoReply@BookMyHome.Test"));
            message.To.Add(new MailboxAddress(emailDto.Name, emailDto.Email));
            message.Subject = emailDto.Subject;

            var builder = new BodyBuilder();

            var logoPath = Path.Combine(AppContext.BaseDirectory, "Assets", "BookMyHome-logo.png");

            var logo = builder.LinkedResources.Add(logoPath);
            logo.ContentId = MimeUtils.GenerateMessageId();

            builder.HtmlBody = emailDto.Body.Replace("{{LogoCid}}", $"cid:{logo.ContentId}");

            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();

            var smtpHost = appsettings.GetValue<string>("SMTP:Host") ?? throw new InvalidOperationException("SMTP Host is missing");
            var smtpPort = appsettings.GetValue<int>("SMTP:Port");

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Connecting to SMTP server {SmtpHost} on port {SmtpPort}", smtpHost, smtpPort);

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
