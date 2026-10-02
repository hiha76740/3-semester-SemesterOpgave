using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;

namespace BookMyHome.Web.ServiceInterfaces;

public interface IBookingService
{
    Task<int> MakeBookingAsync(CreateBookingRequest request);

    Task<IReadOnlyList<UserBookingResponse>> GetUserBookingsAsync();

    Task CancelBookingAsync(Guid id);
}
