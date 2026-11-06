using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Listings;
using AccomodationService.FacadeLib.Commands.Interfaces.Listings;
using BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Listings;

/// <summary>
/// 
/// </summary>
/// <param name="repo"></param>
public class DeleteListingHandler(IAccomodationRepository repo) : IDeleteListingHandler
{
    async Task IDeleteListingHandler.HandleAsync(DeleteListingCommand command)
    {
        try
        {
            var accomodationId = new AccomodationId(command.AccomodationId);
            var hostId = new HostId(command.HostId);
            var listingId = new ListingId(command.ListingId);

            var accomodation = await repo.GetAccomodationWithListingsAsync(accomodationId)
                ?? throw new NotFoundException("Accomodation was not found");

            if (accomodation.HostId != hostId)
                throw new UnauthorizedAccessException("Deletion aborted, only the owner can delete listings");

            accomodation.RemoveListing(listingId);

            await repo.UpdateAsync(accomodation, listingId, command.RowVersion);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Something went wrong doing deletion of listing", ex);
        }
    }
}
