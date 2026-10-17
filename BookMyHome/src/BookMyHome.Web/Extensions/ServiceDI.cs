using BookMyHome.Web.ServiceInterfaces;
using BookMyHome.Web.Services;

namespace BookMyHome.Web.Extensions
{
    public static class ServiceDI
    {
        public static IServiceCollection AddBookMyHomeServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccomodationService, AccomodationService>();
            services.AddScoped<IListingService, ListingService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IFacilityService, FacilityService>();

            return services;
        }
    }
}
