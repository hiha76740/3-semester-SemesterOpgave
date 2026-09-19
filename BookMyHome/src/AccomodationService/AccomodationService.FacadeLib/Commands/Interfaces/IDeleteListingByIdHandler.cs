using AccomodationService.FacadeLib.Commands.DTOs;

namespace AccomodationService.FacadeLib.Commands.Interfaces;

public interface IDeleteListingByIdHandler
{
    Task HandleAsync(DeleteListingByIdCommand command);
}
