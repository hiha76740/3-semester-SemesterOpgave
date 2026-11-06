namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;

/// <summary>
/// 
/// </summary>
/// <param name="HostId"></param>
/// <param name="AccomodationId"></param>
/// <param name="ListingId"></param>
/// <param name="ListingName"></param>
/// <param name="DailyPrice"></param>
/// <param name="HouseRules"></param>
/// <param name="AccomodationType"></param>
/// <param name="Status"></param>
/// <param name="RowVersion"></param>
/// <param name="ImageStream"></param>
/// <param name="Extension"></param>
public record UpdateListingCommand(
    Guid HostId,
    Guid AccomodationId,
    Guid ListingId,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string Status,
    byte[] RowVersion,
    Stream? ImageStream,
    string? Extension
    );
