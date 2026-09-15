using AccomodationService.FacadeLib.Commands.DTOs;

namespace AccomodationService.FacadeLib.Commands.Interfaces;

public interface ICreateAccomodationHandler
{
    Task Handle(CreateAccomodationCommand command);
}
