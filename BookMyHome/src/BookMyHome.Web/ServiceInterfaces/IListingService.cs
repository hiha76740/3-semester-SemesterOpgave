using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Microsoft.AspNetCore.Components.Forms;

namespace BookMyHome.Web.ServiceInterfaces;

/// <summary>
/// 
/// </summary>
public interface IListingService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<ListingResponse>> GetAllListingsAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <param name="listingId"></param>
    /// <returns></returns>
    Task<ListingResponse> GetListingDetailsAsync(Guid accomodationId, Guid listingId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="listingId"></param>
    /// <returns></returns>
    Task<Guid> GetAccomodationIdByListingId(Guid listingId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ListingResponse>> GetAllAvailiableListingsByPeriod(DateOnly startDate, DateOnly endDate);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ListingResponse>> GetAccomodationListings(Guid accomodationId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <param name="listingId"></param>
    /// <param name="request"></param>
    /// <param name="imageFile"></param>
    /// <returns></returns>
    Task<int> UpdateListing(Guid accomodationId, Guid listingId, UpdateListingRequest request, IBrowserFile? imageFile);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="imageFile"></param>
    /// <returns></returns>
    Task<int> Create(CreateListingRequest request, IBrowserFile? imageFile);
}
