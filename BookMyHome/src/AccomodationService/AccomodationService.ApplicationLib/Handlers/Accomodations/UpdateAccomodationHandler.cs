using AccomodationService.ApplicationLib.Handlers.Services;
using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;
using AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Accomodations;

public class UpdateAccomodationHandler(IAccomodationRepository repo, IImageStorageService imageStorage) : IUpdateAccomodationHandler
{
    async Task<bool> IUpdateAccomodationHandler.HandleAsync(UpdateAccomodationCommand command)
    {
        try
        {
            var hostId = new HostId(command.UserId);
            var accomodationId = new AccomodationId(command.AccomodationId);

            var accomodation = await repo.GetAccomodationWithFacilitiesAsync(accomodationId);

            if (accomodation == null)
                throw new NotFoundException("accomodation was not found");

            if (accomodation.HostId != hostId)
                throw new UnauthorizedAccessException("Only the owner can update the accomodation");

            var isValid = Enum.TryParse<AccomodationStatus>(command.Status, out var status);

            if (isValid == false)
                throw new NotFoundException($"{command.Status} is not valid");


            var changesMade = false;

            if (accomodation.Status != status)
            {
                accomodation.UpdateStatus(status);
                changesMade = true;
            }


            var currentFacilityIds = accomodation.facilities
                .Select(f => f.Id.Value)
                .ToHashSet();

            var requestedFacilityIds = command.FacilitiesIds.ToHashSet();

            var facilitiesToAdd = requestedFacilityIds
                .Except(currentFacilityIds);

            var facilitiesToRemove = accomodation.facilities
                .Where(f => requestedFacilityIds.Contains(f.Id.Value) == false)
                .ToList();

            foreach (var facilityId in facilitiesToAdd)
            {
                var facility = await repo.GetFacilityByIdAsync(
                    new FacilityId(facilityId));

                if (facility != null)
                {
                    accomodation.AddFacility(facility);
                    changesMade = true;
                }
            }

            foreach (var facility in facilitiesToRemove)
            {
                accomodation.RemoveFacility(facility);
                changesMade = true;
            }

            if (command.imageStream != null && command.extension != null)
            {
                var fileName = await imageStorage.SaveAsync(command.imageStream, command.extension);
                accomodation.SetImage(fileName);
                changesMade = true;
            }

            if (changesMade == true)
                await repo.SaveAsync();

            return changesMade;
        }
        catch (Exception ex)
        {

            throw new ApplicationException(ex.Message, ex);
        }

    }
}
