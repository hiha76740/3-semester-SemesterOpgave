namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;

public record UpdateListingCommand(
    Guid HostId,
    Guid AccomodationId,
    Guid ListingId,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string status,
    byte[] RowVersion
    );
