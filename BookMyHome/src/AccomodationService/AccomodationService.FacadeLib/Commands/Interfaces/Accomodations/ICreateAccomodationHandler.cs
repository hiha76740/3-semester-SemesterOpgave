using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

/// <summary>
/// 
/// </summary>
public interface ICreateAccomodationHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(CreateAccomodationCommand command);
}
