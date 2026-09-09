using BookingService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookingService.InfrastructureLib.Extensions;

public static class DatabaseDI
{
    public static IServiceCollection AddDatabaseDI(this IServiceCollection services, IConfiguration configuration)
    {
        throw new NotImplementedException();

        //TODO: change when implementing database
        var conn = configuration.GetConnectionString("BookingDB");
        services.AddDbContext<BookingDbContext>(options =>
        options.UseSqlServer(conn));

        return services;
    }
}
