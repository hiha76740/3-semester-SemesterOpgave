namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;


public record UpdateListingHouseRulesCommand(Guid HostId, Guid AccomodationId, Guid ListingId, string HouseRules, byte[] RowVersion);
