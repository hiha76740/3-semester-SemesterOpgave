namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;

/// <summary>
/// 
/// </summary>
/// <param name="HostId"></param>
/// <param name="AccomodationId"></param>
/// <param name="ListingId"></param>
/// <param name="RowVersion"></param>
public record DeleteListingCommand(Guid HostId, Guid AccomodationId, Guid ListingId, byte[] RowVersion);
