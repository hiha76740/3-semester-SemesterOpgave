using AccomodationService.ApplicationLib.Handlers.Services;
using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Listings;
using AccomodationService.FacadeLib.Commands.Interfaces.Listings;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Listings;

public class CreateListingHandler(IAccomodationRepository accomodationRepo, IImageStorageService imageStorage) : ICreateListingHandler
{
    async Task ICreateListingHandler.HandleAsync(CreateListingCommand command)
    {
        var hostId = new HostId(command.HostId);
        var accomodationId = new AccomodationId(command.AccomodationId);

        var accomodation = await accomodationRepo.GetAccomodationByIdAsync(accomodationId);

        if (accomodation == null)
            throw new NotFoundException("Accomodation not found");

        if (accomodation.HostId != hostId)
            throw new UnauthorizedAccessException("Only the owner can create listings.");

        var typeIsValid = Enum.TryParse<AccomodationType>(command.AccomodationType, out var type);

        if (typeIsValid == false)
            throw new NotFoundException("Accomodation Type is not valid");

        var listingId = accomodation.CreateListing(
            command.ListingName,
            command.DailyPrice,
            command.HouseRules,
            type
            );

        if (command.ImageStream != null && command.Extension != null)
        {
            var fileName = await imageStorage.SaveAsync(command.ImageStream, command.Extension);

            accomodation.SetListingImage(listingId, fileName);
        }

        await accomodationRepo.SaveAsync();
    }
}
