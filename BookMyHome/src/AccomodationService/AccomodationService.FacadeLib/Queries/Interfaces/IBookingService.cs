namespace AccomodationService.FacadeLib.Queries.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IBookingService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    Task<bool> IsAvailableAsync(
        Guid accomodationId,
        DateOnly startDate,
        DateOnly endDate
        );
}
