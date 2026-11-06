namespace BookMyHome.Yarp.Extensions;

/// <summary>
/// 
/// </summary>
public static class CorsDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="policyName"></param>
    /// <returns></returns>
    public static IServiceCollection AddBookMyHomeCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(policyName, policy =>
            {
                policy.WithOrigins(
                    "https://localhost:7179",
                    "https://localhost:8082",
                    "https://localhost:21007",
                    "https://localhost:8091")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });
        });

        return services;
    }
}
