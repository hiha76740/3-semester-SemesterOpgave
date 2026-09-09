using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;

namespace BookingService.InfrastructureLib.Services;

public class AccomodationService : IAccomodationService
{
    Task<bool> IAccomodationService.AccomodationExistAsync(AccomodationId id)
    {
        throw new NotImplementedException();
    }
}
