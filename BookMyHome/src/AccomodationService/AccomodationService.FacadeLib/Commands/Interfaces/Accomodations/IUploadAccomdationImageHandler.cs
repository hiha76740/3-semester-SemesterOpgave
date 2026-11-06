using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

/// <summary>
/// 
/// </summary>
public interface IUploadAccomdationImageHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(UploadAccomdationImageCommand command);
}
