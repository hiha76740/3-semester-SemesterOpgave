using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

public interface ICreateAccomodationHandler
{
    Task HandleAsync(CreateAccomodationCommand command);
}
