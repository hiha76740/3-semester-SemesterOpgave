namespace EmailService.ApplicationLib.Services;

public interface IEmailSenderService
{
    Task SendAsync(string recipientName, string recipientEmail, string subject, string body);
}
