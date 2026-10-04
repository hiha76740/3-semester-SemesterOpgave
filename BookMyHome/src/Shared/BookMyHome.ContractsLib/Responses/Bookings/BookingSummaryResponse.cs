namespace BookMyHome.ContractsLib.Responses.Bookings;

public record BookingSummaryResponse(
    Guid BookingId,
    string ListingName, 
    string ListingType,
    string City,
    string Country, 
    DateOnly StartDate, 
    DateOnly EndDate, 
    decimal Price,
    string BookingStatus);
