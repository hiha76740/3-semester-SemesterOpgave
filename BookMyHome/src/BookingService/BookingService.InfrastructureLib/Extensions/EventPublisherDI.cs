using BookingService.ApplicationLib.Services;
using BookingService.InfrastructureLib.EventPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

public static class EventPublisherDI
{
    public static IServiceCollection AddEventPublisherDI(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, DaprIntegrationEventPublisher>();

        return services;
    }
}
