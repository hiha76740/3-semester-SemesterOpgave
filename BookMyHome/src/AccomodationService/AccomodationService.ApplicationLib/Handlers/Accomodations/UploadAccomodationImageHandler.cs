using AccomodationService.ApplicationLib.Handlers.Services;
using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;
using AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Accomodations;

internal class UploadAccomodationImageHandler(IAccomodationRepository repo, IImageStorageService imageStorage) : IUploadAccomdationImageHandler
{
    async Task IUploadAccomdationImageHandler.HandleAsync(UploadAccomdationImageCommand command)
    {
        var accomdationId = new AccomodationId(command.AccomodationId);
        var hostId = new HostId(command.UserId);

        var accomodation = await repo.GetAccomodationByIdAsync(accomdationId);

        if (accomodation == null)
            throw new NotFoundException("Upload of image aborted, Accomodation not found");

        if (accomodation.HostId != hostId)
            throw new UnauthorizedAccessException("Only the owner of the accomodation can upload image");

        var fileName = await imageStorage.SaveAsync(command.ImageStream, command.Extension);

        accomodation.SetImage(fileName);

        await repo.SaveAsync();
    }
}
