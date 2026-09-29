namespace BookMyHome.ContractsLib.Responses.Bookings;

public record UserBookingResponse(
    string ListingName, 
    string ListingType,
    string City,
    string Country, 
    DateOnly StartDate, 
    DateOnly EndDate, 
    decimal Price);
