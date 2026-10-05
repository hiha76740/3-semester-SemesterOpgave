using AccomodationService.ApplicationLib.Handlers.Services;
using AccomodationService.FacadeLib.Queries.Interfaces;
using AccomodationService.InfrastructureLib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.InfrastructureLib.Extensions;

public static class ServiceDI
{
    public static IServiceCollection AddServiceDI(this IServiceCollection services, string imageDirectory)
    {
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IImageStorageService>(serviceProvider => new LocalImageStorageService(imageDirectory));


        return services;
    }
}
