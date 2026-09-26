using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Listings;
using AccomodationService.FacadeLib.Commands.Interfaces.Listings;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Listings;

internal class DeleteListingHandler(IAccomodationRepository repo) : IDeleteListingHandler
{
    async Task IDeleteListingHandler.HandleAsync(DeleteListingCommand command)
    {
        try
        {
            var accomodationId = new AccomodationId(command.AccomodationId);
            var hostId = new HostId(command.HostId);
            var listingId = new ListingId(command.ListingId);

            var accomodation = await repo.GetAccomodationWithListingsAsync(accomodationId);

            if (accomodation == null)
                throw new NotFoundException("Accomodation was not found");

            if (accomodation.HostId != hostId)
                throw new UnauthorizedAccessException("Deletion aborted, Unauthorized Access");

            accomodation.RemoveListing(listingId);

            await repo.UpdateAsync(accomodation, listingId, command.RowVersion);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Something went wrong doing deletion of listing", ex);
        }
    }
}
