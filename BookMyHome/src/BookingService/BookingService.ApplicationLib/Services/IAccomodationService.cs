using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookingService.ApplicationLib.Services;
/// <summary>
/// 
/// </summary>
public interface IAccomodationService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> AccomodationExistAsync(AccomodationId id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <returns></returns>
    Task<Guid> GetAccmodationHostIdAsync(AccomodationId accomodationId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <param name="listingId"></param>
    /// <returns></returns>
    Task<AccomodationSummaryResponse> GetAccomodationSummaryAsync(Guid accomodationId, Guid listingId);
}
