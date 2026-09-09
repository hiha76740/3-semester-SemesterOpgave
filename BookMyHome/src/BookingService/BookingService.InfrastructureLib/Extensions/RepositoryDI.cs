using BookingService.ApplicationLib.Repositories;
using BookingService.InfrastructureLib.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

public static class RepositoryDI
{
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
    {
        services.AddScoped<IBookingRepository, BookingRepository>();


        return services;
    }
}
