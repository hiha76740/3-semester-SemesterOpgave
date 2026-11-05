namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;

public record DeleteListingCommand(Guid HostId, Guid AccomodationId, Guid ListingId, byte[] RowVersion);
