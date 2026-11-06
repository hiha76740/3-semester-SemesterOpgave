using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.InfrastructureLib.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class RepositoryDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
    {
        services.AddScoped<IAccomodationRepository, AccomodationRepository>();

        return services;
    }
}
