using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;

namespace BookingService.ApplicationLib.Repositories;

/// <summary>
/// 
/// </summary>
public interface IBookingRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Booking?> GetBookingByIdAsync(BookingId id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="accomodationId"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    Task<bool> HasOverlapingBookingAsync(AccomodationId accomodationId, DateOnly startDate, DateOnly endDate);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="booking"></param>
    /// <returns></returns>
    Task CreateAsync(Booking booking);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task SaveAsync();
}
