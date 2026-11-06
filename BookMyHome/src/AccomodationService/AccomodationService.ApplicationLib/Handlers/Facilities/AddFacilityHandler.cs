using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Facilities;
using AccomodationService.FacadeLib.Commands.Interfaces.Facilities;
using BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Facilities;

/// <summary>
/// 
/// </summary>
/// <param name="repo"></param>
public class AddFacilityHandler(IAccomodationRepository repo) : IAddFacilityHandler
{
    async Task IAddFacilityHandler.Handle(AddFacilityCommand command)
    {
        try
        {
            var accomodationId = new AccomodationId(command.AccomodationId);
            var facilityId = new FacilityId(command.FacilityId);
            var hostId = new HostId(command.HostId);

            var accomodation = await repo.GetAccomodationWithFacilitiesAsync(accomodationId);
            var facility = await repo.GetFacilityByIdAsync(facilityId);


            if (accomodation == null)
                throw new NotFoundException("Accomodation was not found");

            if (facility == null)
                throw new NotFoundException("Facility was not found");

            if (accomodation.HostId != hostId)
                throw new UnauthorizedAccessException("Only the owner of the accomodation can add facilities");

            accomodation.AddFacility(facility);

            await repo.SaveAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error while adding facility", ex);
        }
    }
}
