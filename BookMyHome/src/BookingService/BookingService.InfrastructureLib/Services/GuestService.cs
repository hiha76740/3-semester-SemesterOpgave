using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;

namespace BookingService.InfrastructureLib.Services;

public class GuestService : IGuestService
{
    //TODO: change when we learn about calling other services
    Task<bool> IGuestService.GuestExistAsync(GuestId id)
    {
        return Task.FromResult(true);
    }
}
