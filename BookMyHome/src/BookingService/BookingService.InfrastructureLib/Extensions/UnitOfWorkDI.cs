using BookingService.ApplicationLib.UnitOfWork;
using BookingService.InfrastructureLib.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

public static class UnitOfWorkDI
{
    public static IServiceCollection AddUnitOfWorkDI(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
