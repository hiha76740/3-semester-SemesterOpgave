using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IListingService
    {
        Task<IReadOnlyList<ListingResponse>> GetAllListingsAsync();
        Task<ListingResponse> GetListingAsync(Guid accomodationId,Guid listingId);

        Task<Guid> GetAccomodationIdByListingId(Guid listingId);

        Task<IReadOnlyList<ListingResponse>> GetAllAvailiableListingsByPeriod(DateOnly start, DateOnly end);
        Task<IReadOnlyList<ListingResponse>> GetAccomodationListings(Guid accomodationId);
        
        Task<int> UpdateListing(Guid accomodationId, Guid listingId, UpdateListingRequest request);
        Task<int> Create(CreateListingRequest request);
    }
}
