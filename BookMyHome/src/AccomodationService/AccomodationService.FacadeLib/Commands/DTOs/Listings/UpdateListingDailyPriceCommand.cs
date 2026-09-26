namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;

public record UpdateListingDailyPriceCommand(Guid HostId,Guid AccomodationId, Guid ListingId, decimal Price, byte[] RowVersion);
