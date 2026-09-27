using AccomodationService.FacadeLib.Queries.Interfaces;
using AccomodationService.InfrastructureLib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.InfrastructureLib.Extensions;

public static class ServiceDI
{
    public static IServiceCollection AddServiceDI(this IServiceCollection services)
    {
        services.AddScoped<IBookingService, BookingService>();

        return services;
    }
}
