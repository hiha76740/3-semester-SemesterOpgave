using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;
using AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;

namespace AccomodationService.ApplicationLib.Handlers.Accomodations;

public class CreateAccomodationHandler(IAccomodationRepository accomodationRepo) : ICreateAccomodationHandler
{
    async Task ICreateAccomodationHandler.Handle(CreateAccomodationCommand command)
    {
        var hostId = new HostId(command.HostId);

        var accomodationExsist = await accomodationRepo.AccomodationExsistByAddress(
            hostId,
            command.Street,
            command.PostalCode,
            command.City,
            command.Country
            );

        if (accomodationExsist == true)
            throw new InvalidOperationException("You already have a accomodation on this address");

        var facilities = new List<Facility>();

        if (command.FacilitiesIds.Count > 0)
        {
            foreach (var facilityId in command.FacilitiesIds)
            {
                var facilityKey = new FacilityId(facilityId);
                var facility = await accomodationRepo.GetFacilityByIdAsync(facilityKey);

                if (facility != null)
                    facilities.Add(facility);
            }
        }

        var accomodation = Accomodation.Create(
            hostId,
            command.Title,
            command.Street,
            command.PostalCode,
            command.City,
            command.Country,
            facilities
            );

        await accomodationRepo.CreateAsync(accomodation);

        await accomodationRepo.SaveAsync();
    }
}
