namespace AccomodationService.FacadeLib.Commands.DTOs;

public record DeleteListingCommand(Guid HostId, Guid AccomodationId, Guid ListingId, byte[] RowVersion);
