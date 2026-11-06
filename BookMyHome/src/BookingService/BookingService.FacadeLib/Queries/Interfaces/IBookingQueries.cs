using BookingService.FacadeLib.Queries.DTOs;

namespace BookingService.FacadeLib.Queries.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IBookingQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<BookingDTO>> GetAllAsync();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BookingDTO?> GetBookingByIdAsync(Guid id);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    Task<bool> Checkavailability(Guid accomodationId, DateOnly startDate, DateOnly endDate);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<IReadOnlyList<BookingSummaryDto>> GetAllUserBookings(Guid userId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomdationId"></param>
    /// <returns></returns>
    Task<IReadOnlyList<BookingSummaryDto>> GetAllAccomdationBookings(Guid accomdationId);
}
