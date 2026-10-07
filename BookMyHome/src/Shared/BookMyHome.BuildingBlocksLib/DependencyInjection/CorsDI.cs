using Microsoft.Extensions.DependencyInjection;

namespace BookMyHome.BuildingBlocksLib.DependencyInjection;

public static class CorsDI
{
    public static IServiceCollection AddBookMyHomeCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(policyName, policy =>
            {
                policy.WithOrigins(
                    "https://localhost:7179",
                    "https://localhost:8082")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });
        });

        return services;
    }
}

