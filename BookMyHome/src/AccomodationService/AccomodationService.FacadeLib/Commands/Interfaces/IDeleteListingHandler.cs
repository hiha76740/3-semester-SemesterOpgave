using AccomodationService.FacadeLib.Commands.DTOs;

namespace AccomodationService.FacadeLib.Commands.Interfaces;

public interface IDeleteListingHandler
{
    Task HandleAsync(DeleteListingCommand command);
}
