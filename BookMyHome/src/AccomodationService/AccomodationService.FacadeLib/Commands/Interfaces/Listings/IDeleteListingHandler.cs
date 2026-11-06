using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;

/// <summary>
/// 
/// </summary>
public interface IDeleteListingHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(DeleteListingCommand command);
}
