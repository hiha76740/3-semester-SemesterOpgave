namespace BookingService.FacadeLib.Queries.DTOs;

public record BookingSummaryDto(
    Guid BookingId,
    string ListingName,
    string ListingType,
    string City,
    string Country,
    DateOnly StartDate,
    DateOnly EndDate,
    decimal Price,
    string BookingStatus);
