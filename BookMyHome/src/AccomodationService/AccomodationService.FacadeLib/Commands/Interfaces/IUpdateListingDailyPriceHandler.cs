using AccomodationService.FacadeLib.Commands.DTOs;

namespace AccomodationService.FacadeLib.Commands.Interfaces;

public interface IUpdateListingDailyPriceHandler
{
    Task HandleAsync(UpdateListingDailyPriceCommand command);
}
