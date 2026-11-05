using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

public interface IUpdateAccomodationStatusHandler
{
    Task HandleAsync(UpdateAccomodationStatusCommand command);
}
