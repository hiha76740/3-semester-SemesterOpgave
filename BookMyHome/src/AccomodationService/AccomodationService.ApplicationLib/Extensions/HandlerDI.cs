using AccomodationService.ApplicationLib.Handlers.Accomodations;
using AccomodationService.ApplicationLib.Handlers.Facilities;
using AccomodationService.ApplicationLib.Handlers.Listings;
using AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;
using AccomodationService.FacadeLib.Commands.Interfaces.Facilities;
using AccomodationService.FacadeLib.Commands.Interfaces.Listings;
using Microsoft.Extensions.DependencyInjection;

namespace AccomodationService.ApplicationLib.Extensions;

/// <summary>
/// 
/// </summary>
public static class HandlerDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddHandlerDI(this IServiceCollection services)
    {
        services.AddScoped<ICreateAccomodationHandler, CreateAccomodationHandler>();
        services.AddScoped<ICreateListingHandler, CreateListingHandler>();
        services.AddScoped<IUpdateListingHandler, UpdateListingHandler>();
        services.AddScoped<IDeleteListingHandler, DeleteListingHandler>();
        services.AddScoped<IAddFacilityHandler, AddFacilityHandler>();
        services.AddScoped<IRemoveFacilityHandler, RemoveFacilityHandler>();
        services.AddScoped<IUpdateAccomodationStatusHandler, UpdateAccomodationStatusHandler>();
        services.AddScoped<IUploadAccomdationImageHandler, UploadAccomodationImageHandler>();
        services.AddScoped<IUpdateAccomodationHandler, UpdateAccomodationHandler>();
        services.AddScoped<IUploadListingImageHandler, UploadListingImageHandler>();

        return services;
    }
}
