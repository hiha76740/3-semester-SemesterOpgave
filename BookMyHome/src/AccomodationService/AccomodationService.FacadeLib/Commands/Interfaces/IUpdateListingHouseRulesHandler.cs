using AccomodationService.FacadeLib.Commands.DTOs;

namespace AccomodationService.FacadeLib.Commands.Interfaces;

public interface IUpdateListingHouseRulesHandler
{
    Task HandleAsync(UpdateListingHouseRulesCommand command);
}
