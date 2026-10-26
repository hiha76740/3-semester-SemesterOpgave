using EmailService.ApplicationLib.Dtos;

namespace EmailService.ApplicationLib.Services;

public interface IEmailSenderService
{
    Task SendAsync(SendEmailDto email);
}
