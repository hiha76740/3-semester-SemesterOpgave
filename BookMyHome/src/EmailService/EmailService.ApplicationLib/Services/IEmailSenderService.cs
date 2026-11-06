using EmailService.ApplicationLib.Dtos;

namespace EmailService.ApplicationLib.Services;

/// <summary>
/// 
/// </summary>
public interface IEmailSenderService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    Task SendAsync(SendEmailDto email);
}
