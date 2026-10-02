using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Facilities;
using AccomodationService.FacadeLib.Commands.Interfaces.Facilities;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Facilities;

public class RemoveFacilityHandler(IAccomodationRepository repo) : IRemoveFacilityHandler
{
    async Task IRemoveFacilityHandler.Handle(RemoveFacilityCommand command)
    {
		try
		{
			var hostId = new HostId(command.HostId);
			var accomodationId = new AccomodationId(command.AccomodationId);
			var facilityId = new FacilityId(command.FacilityId);

			var accomodation = await repo.GetAccomodationWithFacilitiesAsync(accomodationId);
			var facility = await repo.GetFacilityByIdAsync(facilityId);

            if (accomodation == null)
                throw new NotFoundException("Accomodation was not found");

            if (facility == null)
                throw new NotFoundException("Facility was not found");

			if (accomodation.HostId != hostId)
				throw new UnauthorizedAccessException("Only the owner of the accomodation can remove facilities");

			accomodation.RemoveFacility(facility);

			await repo.SaveAsync();

        }
		catch (Exception)
		{

			throw;
		}


    }
}
