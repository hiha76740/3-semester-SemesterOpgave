using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.InfrastructureLib.Persistence;

namespace UserService.InfrastructureLib.Extensions;

public static class DatabaseDI
{
    public static IServiceCollection AddDatabaseDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UserDbContext>(options =>
        options.UseMySQL(
            configuration.GetConnectionString("UserDB")
            ?? throw new InvalidOperationException(
                "Connection string 'UserDB' mangler."
                )));

        return services;
    }
}
