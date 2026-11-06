using AccomodationService.FacadeLib.Queries.DTOs;

namespace AccomodationService.FacadeLib.Queries.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IFaciltiyQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<FacilityDto>> GetAllFacilitiesAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<FacilityDto?> GetFacilityByIdAsync(Guid id);
}
