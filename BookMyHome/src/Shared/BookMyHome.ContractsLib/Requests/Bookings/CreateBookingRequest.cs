namespace BookMyHome.ContractsLib.Requests.Bookings;

public record CreateBookingRequest(Guid GuestId, Guid AccomodationId, DateOnly StartDate, DateOnly EndDate, decimal Price);
