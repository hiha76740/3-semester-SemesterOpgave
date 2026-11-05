using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;

public interface ICreateListingHandler
{
    Task HandleAsync(CreateListingCommand command);
}
