using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserService.InfrastructureLib.Persistence;

namespace UserService.InfrastructureLib.Extensions;

public static class DatabaseDI
{
    public static IServiceCollection AddDatabaseDI(this IServiceCollection services, IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("UserDB");
        services.AddDbContext<UserDbContext>(options =>
        options.UseSqlServer(conn));

        return services;
    }
}
