using AccomodationService.FacadeLib.Commands.DTOs.Facilities;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Facilities
{
    public interface IRemoveFacilityHandler
    {
        Task Handle(RemoveFacilityCommand command);
    }
}
