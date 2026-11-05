using Microsoft.Extensions.DependencyInjection;
using UserService.ApplicationLib.Repositories;
using UserService.InfrastructureLib.Repositories;

namespace UserService.InfrastructureLib.Extensions;

public static class RepositoryDI
{
    public static IServiceCollection AddRepositoryDI(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
