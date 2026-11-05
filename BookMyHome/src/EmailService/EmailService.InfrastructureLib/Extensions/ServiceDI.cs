using EmailService.ApplicationLib.Services;
using EmailService.InfrastructureLib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.InfrastructureLib.Extensions;

public static class ServiceDI
{
    public static IServiceCollection AddServiceDI(this IServiceCollection services)
    {
        services.AddScoped<IEmailSenderService, MailKitEmailSender>();

        return services;
    }
}
