using BookMyHome.ContractsLib.Responses.Accomodations;

namespace BookMyHome.Web.ServiceInterfaces;

/// <summary>
/// 
/// </summary>
public interface IFacilityService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<FacilityResponse>> GetAllFacilitiesAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="facilityId"></param>
    /// <param name="accomodationId"></param>
    /// <returns></returns>
    Task AddFacilityAsync(Guid facilityId, Guid accomodationId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="facilityId"></param>
    /// <param name="accomodationId"></param>
    /// <returns></returns>
    Task RemoveFacilityAsync(Guid facilityId, Guid accomodationId);
}
