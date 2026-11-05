using AccomodationService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.InfrastructureLib.Extensions;

public static class DatabaseDI
{
    public static IServiceCollection AddDatabaseDI(this IServiceCollection services, IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("AccomodationDB");
        services.AddDbContext<AccomodationDbContext>(options =>
        options.UseSqlServer(conn));

        return services;
    }
}
