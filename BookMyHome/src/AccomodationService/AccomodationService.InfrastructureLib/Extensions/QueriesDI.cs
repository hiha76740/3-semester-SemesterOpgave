using AccomodationService.FacadeLib.Queries.Interfaces;
using AccomodationService.InfrastructureLib.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.InfrastructureLib.Extensions;

public static class QueriesDI
{
    public static IServiceCollection AddQueriesDI(this IServiceCollection services)
    {
        services.AddScoped<IAccomodationQueries, AccomodationQueryHandlerIMPL>();
        services.AddScoped<IListingQueries, ListingQueryHandlerIMPL>();

        return services;
    }
}
