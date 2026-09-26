using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;

public interface IUpdateListingDailyPriceHandler
{
    Task HandleAsync(UpdateListingDailyPriceCommand command);
}
