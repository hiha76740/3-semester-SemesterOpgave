using AccomodationService.FacadeLib.Commands.DTOs.Facilities;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Facilities;

/// <summary>
/// 
/// </summary>
public interface IRemoveFacilityHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task Handle(RemoveFacilityCommand command);
}
