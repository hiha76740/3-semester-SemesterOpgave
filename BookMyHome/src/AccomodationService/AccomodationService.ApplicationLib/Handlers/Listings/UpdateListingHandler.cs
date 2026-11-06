using AccomodationService.ApplicationLib.Handlers.Services;
using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Listings;
using AccomodationService.FacadeLib.Commands.Interfaces.Listings;
using BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Listings;

/// <summary>
/// 
/// </summary>
/// <param name="repo"></param>
/// <param name="imageStorage"></param>
public class UpdateListingHandler(IAccomodationRepository repo, IImageStorageService imageStorage) : IUpdateListingHandler
{
    async Task<bool> IUpdateListingHandler.HandleAsync(UpdateListingCommand command)
    {
        try
        {
            var accomodationId = new AccomodationId(command.AccomodationId);
            var hostId = new HostId(command.HostId);
            var listingId = new ListingId(command.ListingId);

            var accomodation = await repo.GetAccomodationWithListingsAsync(accomodationId)
                ?? throw new NotFoundException("Accomodation was not found");

            if (accomodation.HostId != hostId)
                throw new UnauthorizedAccessException("Update aborted, only the owner can update the listing");

            var listing = accomodation.Listings.FirstOrDefault(l => l.Id == listingId)
                ?? throw new NotFoundException("Listing not found");

            var typeIsValid = Enum.TryParse<AccomodationType>(command.AccomodationType, out var accomodationType);


            if (typeIsValid == false)
                throw new NotFoundException("Accomodation Type not found");

            var statusIsValid = Enum.TryParse<ListingStatus>(command.Status, out var listingStatus);

            if (statusIsValid == false)
                throw new NotFoundException("Listing status not found");

            var changeMade = false;

            if (command.ListingName != listing.ListingName)
            {
                accomodation.UpdateListingName(listingId, command.ListingName);
                changeMade = true;
            }


            if (command.DailyPrice != listing.DailyPrice)
            {
                accomodation.UpdateListingDailyPrice(listingId, command.DailyPrice);
                changeMade = true;
            }


            if (command.HouseRules != listing.HouseRules)
            {
                accomodation.UpdateListingHouseRules(listingId, command.HouseRules);
                changeMade = true;
            }


            if (accomodationType != listing.Type)
            {
                accomodation.UpdateAccomodationType(listingId, accomodationType);
                changeMade = true;
            }

            if (listingStatus != listing.Status)
            {
                accomodation.UpdateListingStatus(listingId, listingStatus);
                changeMade |= true;
            }


            if (command.ImageStream != null && command.Extension != null)
            {
                var fileName = await imageStorage.SaveAsync(command.ImageStream, command.Extension);
                accomodation.SetListingImage(listingId, fileName);
                changeMade = true;
            }

            if (changeMade == true)
                await repo.UpdateAsync(accomodation, listingId, command.RowVersion);

            return changeMade;


        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(ex.Message, ex);
        }
    }
}
