using AccomodationService.FacadeLib.Queries.DTOs;

namespace AccomodationService.FacadeLib.Queries.Interfaces;

public interface IAccomodationQueries
{
    Task<AccomodationDto?> GetAccomodationByIdAsync (Guid id);

    Task<IReadOnlyList<AccomodationDto>> GetAllAccomodationsAsync();

    Task<IReadOnlyList<ListingDto>> GetAllAccomdationListingsAsync (Guid id);

    Task<ListingDto?> GetAccomdationListingByIdAsync(Guid accomodationId, Guid listingId);
}
