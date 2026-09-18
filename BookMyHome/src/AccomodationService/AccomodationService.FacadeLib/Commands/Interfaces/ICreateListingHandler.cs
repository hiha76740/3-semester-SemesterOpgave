using AccomodationService.FacadeLib.Commands.DTOs;

namespace AccomodationService.FacadeLib.Commands.Interfaces;

public interface ICreateListingHandler
{
    Task HandleAsync(CreateListingCommand command);
}
