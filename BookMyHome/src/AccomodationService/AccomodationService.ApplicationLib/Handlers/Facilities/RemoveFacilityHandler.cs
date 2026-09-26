using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
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
			var accomodationId = new AccomodationId(command.AccomodationId);
			var facilityId = new FacilityId(command.FacilityId);

			var accomodationTask = repo.GetAccomodationByIdAsync(accomodationId);
			var facilityTask = repo.GetFacilityByIdAsync(facilityId);

			await Task.WhenAll(accomodationTask, facilityTask);

			var accomodation = accomodationTask.Result;
			var facility = facilityTask.Result;

            if (accomodation == null)
                throw new NotFoundException("Accomodation was not found");

            if (facility == null)
                throw new NotFoundException("Facility was not found");

			accomodation.RemoveFacility(facility);

			await repo.SaveAsync();

        }
		catch (Exception)
		{

			throw;
		}


    }
}
