namespace BookingService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="BookingId"></param>
/// <param name="BookingNumber"></param>
/// <param name="ListingName"></param>
/// <param name="ListingType"></param>
/// <param name="City"></param>
/// <param name="Country"></param>
/// <param name="StartDate"></param>
/// <param name="EndDate"></param>
/// <param name="Price"></param>
/// <param name="BookingStatus"></param>
public record BookingSummaryDto(
    Guid BookingId,
    int BookingNumber,
    string ListingName,
    string ListingType,
    string City,
    string Country,
    DateOnly StartDate,
    DateOnly EndDate,
    decimal Price,
    string BookingStatus);
