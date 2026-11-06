using AccomodationService.FacadeLib.Queries.Interfaces;
using AccomodationService.InfrastructureLib.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.InfrastructureLib.Extensions;


/// <summary>
///
/// </summary>
public static class QueriesDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddQueriesDI(this IServiceCollection services)
    {
        services.AddScoped<IAccomodationQueries, AccomodationQueryHandlerIMPL>();
        services.AddScoped<IListingQueries, ListingQueryHandlerIMPL>();
        services.AddScoped<IFaciltiyQueries, FacilityQueryHandlerIMPL>();

        return services;
    }
}
