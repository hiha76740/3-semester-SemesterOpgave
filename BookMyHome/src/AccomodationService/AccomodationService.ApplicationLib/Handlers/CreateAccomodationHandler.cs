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

        var accomodation = Accomodation.Create(
            hostId,
            command.Title,
            command.Street,
            command.PostalCode,
            command.City,
            command.Country
            );

        await accomodationRepo.CreateAsync(accomodation);

        await accomodationRepo.SaveAsync();
    }
}
