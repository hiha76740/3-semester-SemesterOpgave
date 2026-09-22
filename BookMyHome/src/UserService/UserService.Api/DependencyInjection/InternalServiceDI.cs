using UserService.Api.Services;

namespace UserService.Api.DependencyInjection
{
    public static class InternalServiceDI
    {
        public static IServiceCollection AddInternalServiceDI(this IServiceCollection services)
        {
            services.AddScoped<ICookieService, CookieService>();

            return services;
        }
    }
}
