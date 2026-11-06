using BookingService.ApplicationLib.Services;
using BookingService.InfrastructureLib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class ServicesDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddServicesDI(this IServiceCollection services)
    {
        services.AddScoped<IGuestService, GuestService>();
        services.AddScoped<IAccomodationService, AccomodationService>();
        services.AddScoped<IListingService, ListingService>();

        return services;
    }
}
