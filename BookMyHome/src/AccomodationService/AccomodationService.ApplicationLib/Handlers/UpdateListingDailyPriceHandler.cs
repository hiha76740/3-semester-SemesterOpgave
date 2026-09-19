using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs;
using AccomodationService.FacadeLib.Commands.Interfaces;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers;

public class UpdateListingDailyPriceHandler(IAccomodationRepository repo) : IUpdateListingDailyPriceHandler
{
    async Task IUpdateListingDailyPriceHandler.HandleAsync(UpdateListingDailyPriceCommand command)
    {
        var accomodationId = new AccomodationId(command.AccomodationId);
        var hostId = new HostId(command.HostId);

        var accomodation = await repo.GetAccomodationWithListingsAsync(accomodationId);

        if (accomodation == null)
            throw new NotFoundException("Accomodation was not found");

        if (accomodation.HostId != hostId)
            throw new UnauthorizedAccessException("Update aborted, Unauthorized Access");

        accomodation.UpdateListingDailyPrice(command.ListingId, command.Price);

        await repo.SaveAsync();
    }
}
