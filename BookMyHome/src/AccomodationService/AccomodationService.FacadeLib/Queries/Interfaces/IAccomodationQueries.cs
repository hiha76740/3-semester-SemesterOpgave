using AccomodationService.FacadeLib.Queries.DTOs;

namespace AccomodationService.FacadeLib.Queries.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IAccomodationQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AccomodationDto?> GetAccomodationByIdAsync(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<AccomodationDto>> GetAllAccomodationsAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IReadOnlyList<AccomodationDto>> GetAllAccomodationsCurrentUserAsync(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> CheckIfExistsAsync(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <param name="listingId"></param>
    /// <returns></returns>
    Task<AccomodationSummaryDto?> GetAccomodationSummaryAsync(Guid accomodationId, Guid listingId);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    IReadOnlyList<AccomodationTypeDto> GetAllAccomodationTypes();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomdationId"></param>
    /// <returns></returns>
    Task<Guid?> GetAccomodationHostId(Guid accomdationId);
}
