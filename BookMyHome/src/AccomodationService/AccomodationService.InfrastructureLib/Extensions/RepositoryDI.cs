using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.InfrastructureLib.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.InfrastructureLib.Extensions;

public static class RepositoryDI
{
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
    {
        services.AddScoped<IAccomodationRepository, AccomodationRepository>();

        return services;
    }
}
