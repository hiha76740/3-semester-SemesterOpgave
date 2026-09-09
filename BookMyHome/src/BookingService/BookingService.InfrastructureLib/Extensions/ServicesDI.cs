using BookingService.ApplicationLib.Services;
using BookingService.InfrastructureLib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

public static class ServicesDI
{
    public static IServiceCollection AddServicesDI(this IServiceCollection services)
    {
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IAccomodationService, AccomodationService>();

        return services;
    }
}
