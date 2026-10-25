using EmailService.ApplicationLib.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace EmailService.InfrastructureLib.Services;

public class MailKitEmailSender(IConfiguration appsettings) : IEmailSenderService
{
    async Task IEmailSenderService.SendAsync(
        string recipeientName,
        string recipientEmail,
        string subject,
        string body
        )
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("BookMyHome", "NoReply@BookMyHome.Test"));
        message.To.Add(new MailboxAddress(recipeientName, recipientEmail));
        message.Subject = subject;
        message.Body = new TextPart("plain")
        {
            Text = body
        };

        using var client = new SmtpClient();

        await client.ConnectAsync(
            appsettings.GetValue<string>("SMTP:Host") ?? throw new InvalidOperationException("SMTP Host is missing"),
            appsettings.GetValue<int>("SMTP:Port"),
            SecureSocketOptions.None
            );

        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
