namespace BookMyHome.ContractsLib.Requests;

public record CreateBookingRequest(Guid GuestId, Guid AccomodationId, DateOnly StartDate, DateOnly EndDate, decimal Price);
