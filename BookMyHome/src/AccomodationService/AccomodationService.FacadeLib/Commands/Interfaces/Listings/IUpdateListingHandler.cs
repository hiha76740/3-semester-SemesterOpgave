using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;


/// <summary>
/// 
/// </summary>
public interface IUpdateListingHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task<bool> HandleAsync(UpdateListingCommand command);
}
