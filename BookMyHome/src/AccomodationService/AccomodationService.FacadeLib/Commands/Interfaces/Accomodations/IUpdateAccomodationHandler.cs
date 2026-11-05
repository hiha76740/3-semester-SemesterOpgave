using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

public interface IUpdateAccomodationHandler
{
    Task<bool> HandleAsync(UpdateAccomodationCommand command);
}
