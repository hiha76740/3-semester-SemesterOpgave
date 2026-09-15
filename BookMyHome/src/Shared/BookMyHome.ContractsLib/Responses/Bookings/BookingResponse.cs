namespace BookMyHome.ContractsLib.Responses.Bookings;

public record BookingResponse(Guid Id, Guid GuestId, Guid AccomodationId, DateOnly StartDate, DateOnly EndDate, decimal Price);
