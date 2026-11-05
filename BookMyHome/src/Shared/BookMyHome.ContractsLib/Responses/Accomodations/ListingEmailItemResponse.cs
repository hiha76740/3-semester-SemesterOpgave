namespace BookMyHome.ContractsLib.Responses.Accomodations;

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
