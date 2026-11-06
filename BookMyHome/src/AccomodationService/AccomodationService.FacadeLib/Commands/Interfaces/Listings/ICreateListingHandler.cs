using AccomodationService.FacadeLib.Commands.DTOs.Listings;

namespace AccomodationService.FacadeLib.Commands.Interfaces.Listings;

/// <summary>
/// 
/// </summary>
public interface ICreateListingHandler
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    Task HandleAsync(CreateListingCommand command);
}
