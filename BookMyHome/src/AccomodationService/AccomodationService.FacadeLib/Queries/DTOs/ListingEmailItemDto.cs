namespace AccomodationService.FacadeLib.Queries.DTOs;

public record ListingEmailItemDto(
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string Street,
    string PostalCode,
    string City,
    string Country,
    string[] Facilities,
    string? ImageFileName
    );
