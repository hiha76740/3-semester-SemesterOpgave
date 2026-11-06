using BookingService.InfrastructureLib.EventPublishers;
using BookMyHome.BuildingBlocksLib.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class EventPublisherDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddEventPublisherDI(this IServiceCollection services)
    {
        services.AddScoped<IIntegrationEventPublisher, DaprIntegrationEventPublisher>();

        return services;
    }
}
