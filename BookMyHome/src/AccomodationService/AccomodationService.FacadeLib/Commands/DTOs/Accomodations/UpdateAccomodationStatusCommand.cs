namespace AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

/// <summary>
/// 
/// </summary>
/// <param name="AccomodationId"></param>
/// <param name="UserId"></param>
/// <param name="Status"></param>
public record UpdateAccomodationStatusCommand(
    Guid AccomodationId,
    Guid UserId,
    string Status
    );
