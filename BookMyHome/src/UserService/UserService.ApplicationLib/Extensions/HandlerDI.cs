using Microsoft.Extensions.DependencyInjection;
using UserService.ApplicationLib.Handlers;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class HandlerDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddHandlerDI(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserHandler, RegisterUserHandler>();
        services.AddScoped<ILoginHandler, LoginHandler>();
        services.AddScoped<IRefreshTokensHandler, RefreshTokenHandler>();

        return services;
    }
}
