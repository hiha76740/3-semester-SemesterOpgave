using BookMyHome.Web.States;

namespace BookMyHome.Web.Extensions;

/// <summary>
/// 
/// </summary>
public static class StateDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBookMyHomeState(this IServiceCollection services)
    {
        services.AddScoped<BookingState>();
        services.AddScoped<ListingState>();

        return services;
    }
}
