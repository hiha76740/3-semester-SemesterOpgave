namespace BookMyHome.ContractsLib.Requests.Accomodations;

/// <summary>
/// 
/// </summary>
/// <param name="ListingName"></param>
/// <param name="DailyPrice"></param>
/// <param name="HouseRules"></param>
/// <param name="AccomodationType"></param>
/// <param name="Status"></param>
/// <param name="RowVersion"></param>
public record UpdateListingRequest(
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string Status,
    byte[] RowVersion
    );
