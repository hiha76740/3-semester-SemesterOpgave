namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;

/// <summary>
/// 
/// </summary>
/// <param name="UserId"></param>
/// <param name="AccomodationId"></param>
/// <param name="ListingId"></param>
/// <param name="ImageStream"></param>
/// <param name="Extension"></param>
public record UploadListingImageCommand(Guid UserId, Guid AccomodationId, Guid ListingId, Stream ImageStream, string Extension);
