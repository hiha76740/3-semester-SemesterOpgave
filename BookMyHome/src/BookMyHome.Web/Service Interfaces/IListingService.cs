using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookMyHome.Web.Service_Interfaces
{
    public interface IListingService
    {
        Task<IReadOnlyList<ListingResponse>> GetAllListings();
    }
}
