using AccomodationService.ApplicationLib.Handlers.Accomodations;
using AccomodationService.ApplicationLib.Handlers.Facilities;
using AccomodationService.ApplicationLib.Handlers.Listings;
using AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;
using AccomodationService.FacadeLib.Commands.Interfaces.Facilities;
using AccomodationService.FacadeLib.Commands.Interfaces.Listings;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.ApplicationLib.Extensions;

public static class HandlerDI
{
    public static IServiceCollection AddHandlerDI(this IServiceCollection services)
    {
        services.AddScoped<ICreateAccomodationHandler, CreateAccomodationHandler>();
        services.AddScoped<ICreateListingHandler, CreateListingHandler>();
        services.AddScoped<IUpdateListingDailyPriceHandler, UpdateListingDailyPriceHandler>();
        services.AddScoped<IUpdateListingHouseRulesHandler, UpdateListingHouseRulesHandler>();
        services.AddScoped<IDeleteListingHandler, DeleteListingHandler>();
        services.AddScoped<IAddFacilityHandler, AddFacilityHandler>();
        services.AddScoped<IRemoveFacilityHandler, RemoveFacilityHandler>();

        return services;
    }
}
