using BookMyHome.BuildingBlocksLib.Messaging;
using UserService.Api.Services;
using UserService.InfrastructureLib.EventPublishers;

namespace UserService.Api.DependencyInjection
{
    public static class InternalServiceDI
    {
        public static IServiceCollection AddInternalServiceDI(this IServiceCollection services)
        {
            services.AddScoped<ICookieService, CookieService>();
            services.AddScoped<IIntegrationEventPublisher, DaprIntegrationEventPublisher>();

            return services;
        }
    }
}
