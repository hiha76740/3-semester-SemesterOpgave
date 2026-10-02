using BookingService.DomainLib.ValueObjects;

namespace BookingService.ApplicationLib.Services;

public interface IListingService
{
    Task<bool> ListingExistAsync(ListingId id);
}
