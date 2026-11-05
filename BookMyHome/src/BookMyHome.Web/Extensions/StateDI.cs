using BookMyHome.Web.States;

namespace BookMyHome.Web.Extensions
{
    public static class StateDI
    {
        public static IServiceCollection AddBookMyHomeState(this IServiceCollection services)
        {
            services.AddScoped<BookingState>();
            services.AddScoped<ListingState>();

            return services;
        }
    }
}
