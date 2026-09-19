using AccomodationService.ApplicationLib.Handlers;
using AccomodationService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.ApplicationLib.Extensions;

public static class HandlerDI
{
    public static IServiceCollection AddHandlerDI(this IServiceCollection services)
    {
        services.AddScoped<ICreateAccomodationHandler, CreateAccomodationHandler>();
        services.AddScoped<ICreateListingHandler, CreateListingHandler>();
        services.AddScoped<IUpdateListingDailyPriceHandler, UpdateListingDailyPriceHandler>();

        return services;
    }
}
