namespace AccomodationService.FacadeLib.Commands.DTOs;

public record UpdateListingDailyPriceCommand(Guid HostId,Guid AccomodationId, Guid ListingId, decimal Price, byte[] RowVersion);
