using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;

namespace BookingService.InfrastructureLib.Services;

public class GuestService : IGuestService
{
    Task<bool> IGuestService.GuestExistAsync(GuestId id)
    {
        throw new NotImplementedException();
    }
}
