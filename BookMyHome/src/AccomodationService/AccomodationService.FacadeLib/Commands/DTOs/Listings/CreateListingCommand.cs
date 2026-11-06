namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;

/// <summary>
/// 
/// </summary>
/// <param name="HostId"></param>
/// <param name="AccomodationId"></param>
/// <param name="ListingName"></param>
/// <param name="DailyPrice"></param>
/// <param name="HouseRules"></param>
/// <param name="AccomodationType"></param>
/// <param name="ImageStream"></param>
/// <param name="Extension"></param>
public record CreateListingCommand(
    Guid HostId,
    Guid AccomodationId,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    Stream? ImageStream = null,
    string? Extension = null
    );
