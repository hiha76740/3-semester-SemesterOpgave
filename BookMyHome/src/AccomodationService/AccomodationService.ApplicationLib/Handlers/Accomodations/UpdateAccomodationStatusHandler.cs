using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;
using AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace AccomodationService.ApplicationLib.Handlers.Accomodations;

public class UpdateAccomodationStatusHandler(IAccomodationRepository repo) : IUpdateAccomodationStatusHandler
{
    async Task IUpdateAccomodationStatusHandler.HandleAsync(UpdateAccomodationStatusCommand command)
    {
        var hostId = new HostId(command.UserId);
        var accomodationId = new AccomodationId(command.AccomodationId);

        var accomodation = await repo.GetAccomodationByIdAsync(accomodationId);

        if (accomodation == null)
            throw new NotFoundException("accomodation was not found");

        if (accomodation.HostId != hostId)
            throw new UnauthorizedAccessException("Only the owner can update the status of the accomodation");

        var isValid = Enum.TryParse<AccomodationStatus>(command.Status, out var status);

        if (isValid == false)
            throw new NotFoundException($"{command.Status} is not valid");

        accomodation.UpdateStatus(status);

        await repo.SaveAsync();

    }
}
