using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

public interface IUploadAccomdationImageHandler
{
    Task HandleAsync(UploadAccomdationImageCommand command);
}
