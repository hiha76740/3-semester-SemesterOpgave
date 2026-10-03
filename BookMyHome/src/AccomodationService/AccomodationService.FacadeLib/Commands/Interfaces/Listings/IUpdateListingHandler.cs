using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;

public interface IUpdateListingHandler
{
    Task HandleAsync(UpdateListingCommand command);
}
