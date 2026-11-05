using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookingService.ApplicationLib.Services;

public interface IListingService
{
    Task<ListingEmailItemResponse> GetListingEmailItemAsync(ListingId id);
}
