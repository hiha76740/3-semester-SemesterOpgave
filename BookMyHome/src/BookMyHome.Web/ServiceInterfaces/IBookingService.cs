using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;

namespace BookMyHome.Web.ServiceInterfaces;

public interface IBookingService
{
    Task MakeBooking(CreateBookingRequest request);

    Task<IReadOnlyList<BookingResponse>> GetUserBookingsAsync();
}
