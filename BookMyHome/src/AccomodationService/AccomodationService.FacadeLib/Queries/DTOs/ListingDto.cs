namespace AccomodationService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="ListingId"></param>
/// <param name="AccomodationId"></param>
/// <param name="ListingName"></param>
/// <param name="DailyPrice"></param>
/// <param name="HouseRules"></param>
/// <param name="AccomodationType"></param>
/// <param name="Street"></param>
/// <param name="PostalCode"></param>
/// <param name="City"></param>
/// <param name="Country"></param>
/// <param name="Status"></param>
/// <param name="Facilities"></param>
/// <param name="RowVersion"></param>
/// <param name="ImageFileName"></param>
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
    string Status,
    string[] Facilities,
    byte[] RowVersion,
    string? ImageFileName
    );
