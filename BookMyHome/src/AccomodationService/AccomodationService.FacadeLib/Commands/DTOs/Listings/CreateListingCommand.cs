namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;

public record CreateListingCommand(
    Guid HostId,
    Guid AccomodationId,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType
    );
