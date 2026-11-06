namespace BookMyHome.ContractsLib.Requests.Accomodations;

/// <summary>
/// 
/// </summary>
/// <param name="AccomodationId"></param>
/// <param name="ListingName"></param>
/// <param name="DailyPrice"></param>
/// <param name="HouseRules"></param>
/// <param name="AccomodationType"></param>
public record CreateListingRequest(
    Guid AccomodationId,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType
    );
