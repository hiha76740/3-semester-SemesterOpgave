namespace AccomodationService.FacadeLib.Commands.DTOs;

public record CreateAccomodationCommand(Guid HostId, string Title, string Street, string PostalCode, string City);
