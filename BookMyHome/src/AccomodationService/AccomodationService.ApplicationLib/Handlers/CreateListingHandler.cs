using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs;
using AccomodationService.FacadeLib.Commands.Interfaces;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers;

public class CreateListingHandler(IAccomodationRepository accomodationRepo) : ICreateListingHandler
{
    async Task ICreateListingHandler.HandleAsync(CreateListingCommand command)
    {
        var hostId = new HostId(command.HostId);
        var accomodationId = new AccomodationId(command.AccomodationId);

        var accomodation = await accomodationRepo.GetAccomodationByIdAsync(accomodationId);

        if (accomodation == null)
            throw new NotFoundException("Accomodation not found");

        if (accomodation.HostId != hostId)
            throw new UnauthorizedAccessException("Unauthorized Access");

        var typeIsValid = Enum.TryParse<AccomodationType>(command.AccomodationType, out var type);

        if (typeIsValid == false)
            throw new NotFoundException("Accomodation Type is not valid");

        accomodation.CreateListing(
            command.ListingName,
            command.DailyPrice,
            command.HouseRules,
            type
            );

        await accomodationRepo.SaveAsync();
    }
}
