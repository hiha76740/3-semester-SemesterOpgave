using AccomodationService.FacadeLib.Commands.DTOs;
using AccomodationService.FacadeLib.Commands.Interfaces;

namespace AccomodationService.ApplicationLib.Handlers;

public class CreateAccomodationHandler : ICreateAccomodationHandler
{
    Task ICreateAccomodationHandler.Handle(CreateAccomodationCommand command)
    {
        throw new NotImplementedException();
    }
}
