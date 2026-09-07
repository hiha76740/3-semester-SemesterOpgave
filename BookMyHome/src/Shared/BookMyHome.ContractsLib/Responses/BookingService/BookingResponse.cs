namespace BookMyHome.ContractsLib.Responses.BookingService;

public record BookingResponse(Guid Id, Guid GuestId, Guid AccomodationId, DateOnly StartDate, DateOnly EndDate, decimal Price);
