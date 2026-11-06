using BookMyHome.BuildingBlocksLib.Messaging;
using UserService.Api.Services;
using UserService.InfrastructureLib.EventPublishers;

namespace UserService.Api.DependencyInjection;

/// <summary>
/// 
/// </summary>
public static class InternalServiceDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInternalServiceDI(this IServiceCollection services)
    {
        services.AddScoped<ICookieService, CookieService>();
        services.AddScoped<IIntegrationEventPublisher, DaprIntegrationEventPublisher>();

        return services;
    }
}
