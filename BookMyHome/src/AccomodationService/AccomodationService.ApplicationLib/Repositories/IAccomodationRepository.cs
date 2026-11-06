using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;

namespace AccomodationService.ApplicationLib.Repositories;

/// <summary>
/// 
/// </summary>
public interface IAccomodationRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodation"></param>
    /// <returns></returns>
    Task CreateAsync(Accomodation accomodation);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Accomodation?> GetAccomodationByIdAsync(AccomodationId id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Accomodation?> GetAccomodationWithFacilitiesAsync(AccomodationId id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Accomodation?> GetAccomodationWithListingsAsync(AccomodationId id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodation"></param>
    /// <param name="listingId"></param>
    /// <param name="originalRowVersion"></param>
    /// <returns></returns>
    Task UpdateAsync(Accomodation accomodation, ListingId listingId, byte[] originalRowVersion);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="street"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <param name="country"></param>
    /// <returns></returns>
    Task<bool> AccomodationExsistByAddress(HostId id, string street, string postalCode, string city, string country);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task SaveAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Facility?> GetFacilityByIdAsync(FacilityId id);
}
