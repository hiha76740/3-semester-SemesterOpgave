using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;

public interface IUpdateListingHandler
{
    Task<bool> HandleAsync(UpdateListingCommand command);
}
