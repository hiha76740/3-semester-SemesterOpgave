namespace BookMyHome.ContractsLib.Responses.Bookings;

public record BookingResponse(
    Guid Id,
    int BookingNumber,
    Guid GuestId, 
    Guid AccomodationId, 
    DateOnly StartDate,
    DateOnly EndDate, 
    decimal Price
    );
