namespace AccomodationService.FacadeLib.Commands.DTOs;

public record DeleteListingByIdCommand(Guid HostId, Guid AccomodationId, Guid ListingId);
