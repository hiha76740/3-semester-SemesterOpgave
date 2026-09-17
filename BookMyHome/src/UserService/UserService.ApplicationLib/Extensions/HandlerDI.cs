using Microsoft.Extensions.DependencyInjection;
using UserService.ApplicationLib.Handlers;
using UserService.FacadeLib.Commands.Interfaces;

namespace UserService.ApplicationLib.Extensions;

public static class HandlerDI
{
    public static IServiceCollection AddHandlerDI(this IServiceCollection services)
    {
        services.AddScoped<IRegisterUserHandler, RegisterUserHandler>();
        services.AddScoped<ILoginHandler, LoginHandler>();

        return services;
    }
}
