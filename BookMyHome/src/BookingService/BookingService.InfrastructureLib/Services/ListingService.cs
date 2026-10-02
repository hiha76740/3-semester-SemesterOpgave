using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;

namespace BookingService.InfrastructureLib.Services;

public class ListingService : IListingService
{
    Task<bool> IListingService.ListingExistAsync(ListingId id)
    {
        throw new NotImplementedException();
    }
}
