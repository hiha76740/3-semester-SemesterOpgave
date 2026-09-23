namespace BookMyHome.ContractsLib.Responses.Accomodations;

public record ListingResponse(
    Guid ListingId,
    Guid AccomodationId,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string Street,
    string PostalCode,
    string City,
    string Country
    );
