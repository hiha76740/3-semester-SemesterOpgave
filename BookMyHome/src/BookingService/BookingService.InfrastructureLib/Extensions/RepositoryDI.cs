using BookingService.ApplicationLib.Repositories;
using BookingService.InfrastructureLib.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

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
        services.AddScoped<IBookingRepository, BookingRepository>();


        return services;
    }
}
