using BookingService.ApplicationLib.Handlers;
using BookingService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.ApplicationLib.Extensions;

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
        services.AddScoped<ICreateBookingHandler, CreateBookingHandler>();
        services.AddScoped<ICancelBookingHandler, CancelBookingHandler>();

        return services;
    }
}
