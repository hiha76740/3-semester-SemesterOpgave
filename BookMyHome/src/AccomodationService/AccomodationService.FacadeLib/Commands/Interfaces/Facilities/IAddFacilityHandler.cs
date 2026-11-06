using AccomodationService.FacadeLib.Commands.DTOs.Facilities;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Facilities;

/// <summary>
/// 
/// </summary>
public interface IAddFacilityHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task Handle(AddFacilityCommand command);
}
