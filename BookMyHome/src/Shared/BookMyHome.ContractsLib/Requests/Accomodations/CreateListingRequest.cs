namespace BookMyHome.ContractsLib.Requests.Accomodations;

public record CreateListingRequest(
    Guid AccomodationId,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType
    );
