namespace BookMyHome.ContractsLib.Requests.Bookings;

public record CreateBookingRequest(
    Guid GuestId,
    Guid AccomodationId,
    Guid ListingId,
    DateOnly StartDate,
    DateOnly EndDate,
    decimal Price
    );
