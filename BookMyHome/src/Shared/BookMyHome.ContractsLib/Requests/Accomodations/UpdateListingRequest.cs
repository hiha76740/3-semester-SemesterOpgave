namespace BookMyHome.ContractsLib.Requests.Accomodations;

public record UpdateListingRequest(
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    byte[] RowVersion
    );
