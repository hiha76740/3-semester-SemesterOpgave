using Microsoft.Extensions.DependencyInjection;
using UserService.FacadeLib.Queries.Interfaces;
using UserService.InfrastructureLib.QueryHandlers;

namespace UserService.InfrastructureLib.Extensions;
public static class QueriesDI
{
    public static IServiceCollection AddQueriesDI(this IServiceCollection services)
    {
        services.AddScoped<IUserQueries, UserQueryIMPLHandler>();

        return services;
    }
}
