using BookingService.DomainLib.ValueObjects;

namespace BookingService.ApplicationLib.Services;

public interface IGuestService
{
    Task<bool> GuestExistAsync(GuestId id);
}
