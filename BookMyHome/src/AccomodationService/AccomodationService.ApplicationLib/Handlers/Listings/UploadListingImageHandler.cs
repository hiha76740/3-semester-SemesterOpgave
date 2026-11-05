using AccomodationService.ApplicationLib.Handlers.Services;
using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Listings;
using AccomodationService.FacadeLib.Commands.Interfaces.Listings;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Listings;

public class UploadListingImageHandler(IAccomodationRepository repo, IImageStorageService imageStorage) : IUploadListingImageHandler
{
    async Task IUploadListingImageHandler.HandleAsync(UploadListingImageCommand command)
    {
        var listingId = new ListingId(command.ListingId);
        var accomodationId = new AccomodationId(command.AccomodationId);
        var hostId = new HostId(command.UserId);

        var accomodation = await repo.GetAccomodationWithListingsAsync(accomodationId);

        if (accomodation == null)
            throw new NotFoundException("Upload of image aborted, Accomodation not found");

        if (accomodation.HostId != hostId)
            throw new UnauthorizedAccessException("Only the owner of the accomodation can upload image");

        var fileName = await imageStorage.SaveAsync(command.ImageStream, command.Extension);

        accomodation.SetListingImage(listingId, fileName);

        await repo.SaveAsync();
    }
}
