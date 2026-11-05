namespace AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

public record UpdateAccomodationCommand(
    Guid UserId,
    Guid AccomodationId,
    string Status,
    List<Guid>FacilitiesIds,
    Stream? imageStream,
    string? extension);
