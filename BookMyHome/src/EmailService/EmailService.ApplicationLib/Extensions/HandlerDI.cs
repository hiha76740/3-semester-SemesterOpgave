using EmailService.ApplicationLib.Handlers;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.ApplicationLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class HandlerDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddHandlerDI(this IServiceCollection services)
    {
        services.AddScoped<ISendBookingConfirmationHandler, SendBookingConfirmationHandler>();
        services.AddScoped<ISendUserConfirmationHandler, SendUserConfirmationHandler>();

        return services;
    }
}
