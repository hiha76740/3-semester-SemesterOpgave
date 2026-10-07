namespace AccomodationService.FacadeLib.Commands.DTOs.Listings;

public record UploadListingImageCommand(Guid UserId, Guid ListingId, Stream ImageStream, string Extension);
