namespace BookMyHome.ContractsLib.Events;

/// <summary>
/// 
/// </summary>
/// <param name="BookingNumber"></param>
/// <param name="StartDate"></param>
/// <param name="EndDate"></param>
/// <param name="Price"></param>
/// <param name="ListingName"></param>
/// <param name="DailyPrice"></param>
/// <param name="HouseRules"></param>
/// <param name="AccomodationType"></param>
/// <param name="Street"></param>
/// <param name="PostalCode"></param>
/// <param name="City"></param>
/// <param name="Country"></param>
/// <param name="Facilities"></param>
/// <param name="ImageUrl"></param>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="Email"></param>
public record BookingPlacedIntegrationEvent(
    int BookingNumber,
    DateOnly StartDate,
    DateOnly EndDate,
    decimal Price,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string Street,
    string PostalCode,
    string City,
    string Country,
    string[] Facilities,
    string? ImageUrl,
    string FirstName,
    string LastName,
    string Email
    );
