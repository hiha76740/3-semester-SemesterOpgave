using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;

namespace BookMyHome.Web.ServiceInterfaces;

public interface IBookingService
{
    Task<int> MakeBookingAsync(CreateBookingRequest request);

    Task<IReadOnlyList<BookingSummaryResponse>> GetUserBookingsAsync();

    Task CancelBookingAsync(Guid id);
    Task<IReadOnlyList<BookingSummaryResponse>> GetAccomodationBookingsAsync(Guid id);
}
