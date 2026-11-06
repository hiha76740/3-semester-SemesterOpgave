using BookingService.ApplicationLib.UnitOfWork;
using BookingService.InfrastructureLib.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class UnitOfWorkDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddUnitOfWorkDI(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
