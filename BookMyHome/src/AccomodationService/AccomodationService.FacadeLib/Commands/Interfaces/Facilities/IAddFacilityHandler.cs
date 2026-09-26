using AccomodationService.FacadeLib.Commands.DTOs.Facilities;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Facilities; 

public interface IAddFacilityHandler
{
    Task Handle(AddFacilityCommand command);
}
