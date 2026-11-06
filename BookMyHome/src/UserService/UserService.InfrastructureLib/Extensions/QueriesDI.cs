using Microsoft.Extensions.DependencyInjection;
using UserService.FacadeLib.Queries.Interfaces;
using UserService.InfrastructureLib.QueryHandlers;

namespace UserService.InfrastructureLib.Extensions;
/// <summary>
/// 
/// </summary>
public static class QueriesDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddQueriesDI(this IServiceCollection services)
    {
        services.AddScoped<IUserQueries, UserQueryIMPLHandler>();
        services.AddScoped<IAuthQueries, AuthQueryHandlerIMPL>();

        return services;
    }
}
