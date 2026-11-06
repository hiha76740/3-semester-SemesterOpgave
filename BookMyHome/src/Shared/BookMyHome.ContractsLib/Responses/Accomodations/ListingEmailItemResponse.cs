namespace BookMyHome.ContractsLib.Responses.Accomodations;

/// <summary>
/// 
/// </summary>
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
public record ListingEmailItemResponse(
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string Street,
    string PostalCode,
    string City,
    string Country,
    string[] Facilities,
    string? ImageUrl
    );
