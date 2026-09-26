using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

public interface ICreateAccomodationHandler
{
    Task Handle(CreateAccomodationCommand command);
}
