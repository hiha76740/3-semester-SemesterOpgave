namespace AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

public record CreateAccomodationCommand(Guid HostId, string Title, string Street, string PostalCode, string City, string Country);
