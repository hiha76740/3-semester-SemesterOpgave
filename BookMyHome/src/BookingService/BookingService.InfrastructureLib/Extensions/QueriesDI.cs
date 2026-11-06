using BookingService.FacadeLib.Queries.Interfaces;
using BookingService.InfrastructureLib.QueryHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

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
        services.AddScoped<IBookingQueries, BookingQueryHandlerIMPL>();

        return services;
    }
}
