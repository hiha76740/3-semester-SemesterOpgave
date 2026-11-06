using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookingService.ApplicationLib.Services;
/// <summary>
/// 
/// </summary>
public interface IListingService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ListingEmailItemResponse> GetListingEmailItemAsync(ListingId id);
}
