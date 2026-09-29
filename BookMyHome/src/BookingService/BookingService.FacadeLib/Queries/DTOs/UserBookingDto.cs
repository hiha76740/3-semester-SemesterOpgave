namespace BookingService.FacadeLib.Queries.DTOs;

public record UserBookingDto(
    string ListingName,
    string ListingType,
    string City,
    string Country,
    DateOnly StartDate,
    DateOnly EndDate,
    decimal Price);
