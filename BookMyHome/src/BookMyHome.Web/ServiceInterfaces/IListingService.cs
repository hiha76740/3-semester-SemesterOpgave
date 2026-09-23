using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IListingService
    {
        Task<IReadOnlyList<ListingResponse>> GetAllListingsAsync();

        Task<ListingResponse> GetListingAsync(Guid accomodationId,Guid listingId);

        Task<Guid> GetAccomodationIdByListingId(Guid listingId);
    }
}
