using BookingService.ApplicationLib.Handlers;
using BookingService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.ApplicationLib.Extensions;

public static class HandlerDI
{
    public static IServiceCollection AddHandlerDI(this IServiceCollection services)
    {
        services.AddScoped<ICreateBookingHandler, CreateBookingHandler>();

        return services;
    }
}
