using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;

namespace BookMyHome.Web.ServiceInterfaces;

/// <summary>
/// 
/// </summary>
public interface IBookingService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<int> MakeBookingAsync(CreateBookingRequest request);
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<BookingSummaryResponse>> GetUserBookingsAsync();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task CancelBookingAsync(Guid id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IReadOnlyList<BookingSummaryResponse>> GetAccomodationBookingsAsync(Guid id);
}
