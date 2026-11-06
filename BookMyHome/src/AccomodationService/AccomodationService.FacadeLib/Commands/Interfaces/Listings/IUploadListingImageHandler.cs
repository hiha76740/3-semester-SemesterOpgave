using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;

/// <summary>
/// 
/// </summary>
public interface IUploadListingImageHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(UploadListingImageCommand command);
}
