using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;

public interface IUpdateListingHouseRulesHandler
{
    Task HandleAsync(UpdateListingHouseRulesCommand command);
}
