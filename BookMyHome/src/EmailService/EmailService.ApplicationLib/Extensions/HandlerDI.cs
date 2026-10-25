using EmailService.ApplicationLib.Handlers;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.ApplicationLib.Extensions;

public static class HandlerDI
{
    public static IServiceCollection AddHandlerDI(this IServiceCollection services)
    {
        services.AddScoped<ISendBookingConfirmationHandler, SendBookingConfirmationHandler>();

        return services;
    }
}
