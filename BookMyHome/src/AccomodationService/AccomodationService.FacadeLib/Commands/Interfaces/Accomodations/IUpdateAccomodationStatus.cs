using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

public interface IUpdateAccomodationStatus
{
    Task HandleAsync(UpdateAccomodationStatusCommand command);
}
