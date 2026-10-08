using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Microsoft.AspNetCore.Components.Forms;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IListingService
    {
        Task<IReadOnlyList<ListingResponse>> GetAllListingsAsync();
        Task<ListingResponse> GetListingAsync(Guid accomodationId,Guid listingId);

        Task<Guid> GetAccomodationIdByListingId(Guid listingId);

        Task<IReadOnlyList<ListingResponse>> GetAllAvailiableListingsByPeriod(DateOnly start, DateOnly end);
        Task<IReadOnlyList<ListingResponse>> GetAccomodationListings(Guid accomodationId);
        
        Task<int> UpdateListing(Guid accomodationId, Guid listingId, UpdateListingRequest request, IBrowserFile? imageFile);
        Task<int> Create(CreateListingRequest request, IBrowserFile? imageFile);
    }
}
