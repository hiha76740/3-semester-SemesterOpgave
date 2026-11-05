using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;

public interface IUploadListingImageHandler
{
    Task HandleAsync(UploadListingImageCommand command);
}
