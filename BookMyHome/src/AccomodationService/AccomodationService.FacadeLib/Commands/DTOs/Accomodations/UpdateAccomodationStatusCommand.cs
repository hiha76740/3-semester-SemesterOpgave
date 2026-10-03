namespace AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

public record UpdateAccomodationStatusCommand(Guid AccomodationId, Guid UserId, string Status);
