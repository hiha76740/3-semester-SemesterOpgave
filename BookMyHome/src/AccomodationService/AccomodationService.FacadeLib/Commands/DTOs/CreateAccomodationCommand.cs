namespace AccomodationService.FacadeLib.Commands.DTOs;

public record CreateAccomodationCommand(Guid hostId, string title, string Street, string PostalCode, string City);
