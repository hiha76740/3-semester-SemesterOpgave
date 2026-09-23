using AccomodationService.FacadeLib.Queries.DTOs;

namespace AccomodationService.FacadeLib.Queries.Interfaces;

public interface IListingQueries
{
    Task<IReadOnlyList<ListingDto>> GetAllAccomdationListingsAsync(Guid id);

    Task<ListingDto?> GetAccomdationListingByIdAsync(Guid accomodationId, Guid listingId);

    Task<IReadOnlyList<ListingDto>> GetAllListings();
}
