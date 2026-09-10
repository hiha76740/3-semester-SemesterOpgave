using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;

namespace BookingService.InfrastructureLib.Services;

public class AccomodationService : IAccomodationService
{
    //TODO: change when we learn about calling other services
    Task<bool> IAccomodationService.AccomodationExistAsync(AccomodationId id)
    {
        return Task.FromResult(true);
    }
}
