namespace AccomodationService.FacadeLib.Queries.DTOs;

public record ListingDto(
    Guid ListingId,
    Guid AccomodationId,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string Street,
    string PostalCode,
    string City,
    string Country,
    byte[] RowVersion
    );
