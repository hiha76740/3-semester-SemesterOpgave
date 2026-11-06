using EmailService.ApplicationLib.Services;
using EmailService.InfrastructureLib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class ServiceDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServiceDI(this IServiceCollection services)
    {
        services.AddScoped<IEmailSenderService, MailKitEmailSender>();

        return services;
    }
}
