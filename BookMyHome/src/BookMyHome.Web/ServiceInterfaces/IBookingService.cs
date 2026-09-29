using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;

namespace BookMyHome.Web.ServiceInterfaces;

public interface IBookingService
{
    Task MakeBookingAsync(CreateBookingRequest request);

    Task<IReadOnlyList<BookingResponse>> GetUserBookingsAsync();

    Task CancelBookingAsync(Guid id);
}
