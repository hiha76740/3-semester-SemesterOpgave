using BookMyHome.ContractsLib.Requests.Bookings;

namespace BookMyHome.Web.ServiceInterfaces;

public interface IBookingService
{
    Task MakeBooking(CreateBookingRequest request);
}
