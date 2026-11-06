using AccomodationService.FacadeLib.Queries.DTOs;

namespace AccomodationService.FacadeLib.Queries.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IListingQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ListingDto>> GetAllAccomdationListingsAsync(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <param name="listingId"></param>
    /// <returns></returns>
    Task<ListingDto?> GetListingDetailsByIdAsync(Guid accomodationId, Guid listingId);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<ListingDto>> GetAllListings();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Guid?> GetAccomodationIdByListingId(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    Task<IReadOnlyList<ListingDto>> GetAvailableListings(DateOnly startDate, DateOnly endDate);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> CheckIfExistsAsync(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<ListingEmailItemDto?> GetListingEmailItemAsync(Guid id);
}
