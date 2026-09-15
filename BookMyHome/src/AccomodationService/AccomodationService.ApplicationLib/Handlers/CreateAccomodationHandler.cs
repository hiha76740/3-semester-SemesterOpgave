using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs;
using AccomodationService.FacadeLib.Commands.Interfaces;

namespace AccomodationService.ApplicationLib.Handlers;

public class CreateAccomodationHandler(IAccomodationRepository accomodationRepo) : ICreateAccomodationHandler
{
    async Task ICreateAccomodationHandler.Handle(CreateAccomodationCommand command)
    {
        var hostId = new HostId(command.hostId);

        var accomodation = Accomodation.Create(hostId, command.title);

        await accomodationRepo.CreateAsync(accomodation);

        await accomodationRepo.SaveAsync();
    }
}
