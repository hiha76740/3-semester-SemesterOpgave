using BookingService.FacadeLib.Queries.Interfaces;
using BookingService.InfrastructureLib.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

public static class QueriesDI
{
    public static IServiceCollection AddQueriesDI(this IServiceCollection services)
    {
        services.AddScoped<IBookingQueries, BookingQueryHandlerIMPL>();

        return services;
    }
}
