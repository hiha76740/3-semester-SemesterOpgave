namespace AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

/// <summary>
/// 
/// </summary>
/// <param name="UserId"></param>
/// <param name="AccomodationId"></param>
/// <param name="Status"></param>
/// <param name="FacilitiesIds"></param>
/// <param name="ImageStream"></param>
/// <param name="Extension"></param>
public record UpdateAccomodationCommand(
    Guid UserId,
    Guid AccomodationId,
    string Status,
    List<Guid> FacilitiesIds,
    Stream? ImageStream,
    string? Extension);
