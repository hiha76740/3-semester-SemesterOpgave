using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookingService.ApplicationLib.Services;

public interface IAccomodationService
{
    Task<bool> AccomodationExistAsync(AccomodationId id);

    Task<AccomodationSummaryResponse> GetAccomodationSummaryAsync(Guid accomodationId, Guid listingId);
}
