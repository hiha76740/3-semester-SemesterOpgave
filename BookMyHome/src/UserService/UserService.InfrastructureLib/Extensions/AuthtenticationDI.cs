using Microsoft.Extensions.DependencyInjection;
using UserService.ApplicationLib.Authentication;
using UserService.InfrastructureLib.Authentication;

namespace UserService.InfrastructureLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class AuthtenticationDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddAuthenTicationDI(this IServiceCollection services)
    {
        services.AddScoped<IPasswordHashService, PasswordHashService>();
        services.AddScoped<ITokenService, JwtTokenService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();

        return services;
    }
}
