namespace AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

/// <summary>
/// 
/// </summary>
/// <param name="UserId"></param>
/// <param name="AccomodationId"></param>
/// <param name="ImageStream"></param>
/// <param name="Extension"></param>
public record UploadAccomdationImageCommand(Guid UserId, Guid AccomodationId, Stream ImageStream, string Extension);
