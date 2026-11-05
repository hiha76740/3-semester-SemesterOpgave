namespace BookMyHome.ContractsLib.Responses.Accomodations;

public record AccomodationSummaryResponse(
    string ListingName,
    string ListingType,
    string City,
    string Country
    );
