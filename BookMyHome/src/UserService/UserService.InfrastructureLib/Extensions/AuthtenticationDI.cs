using Microsoft.Extensions.DependencyInjection;
using UserService.ApplicationLib.Authentication;
using UserService.InfrastructureLib.Authentication;

namespace UserService.InfrastructureLib.Extensions;

public static class AuthtenticationDI
{
    public static IServiceCollection AddAuthenTicationDI(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        services.AddScoped<ITokenService, JwtTokenService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();

        return services;
    }
}
