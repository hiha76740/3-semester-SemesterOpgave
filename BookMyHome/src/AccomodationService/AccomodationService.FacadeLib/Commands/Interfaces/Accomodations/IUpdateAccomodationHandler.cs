using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

/// <summary>
/// 
/// </summary>
public interface IUpdateAccomodationHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<bool> HandleAsync(UpdateAccomodationCommand command);
}
