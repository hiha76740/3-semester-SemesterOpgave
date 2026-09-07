using BookingService.DomainLib.ValueObjects;

namespace BookingService.ApplicationLib.Services;

public interface IAccomodationService
{
    Task<bool> AccomodationExistAsync(AccomodationId id);
}
