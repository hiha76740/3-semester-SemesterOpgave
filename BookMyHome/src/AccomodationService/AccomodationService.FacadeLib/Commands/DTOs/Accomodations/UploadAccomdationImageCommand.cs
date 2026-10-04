namespace AccomodationService.FacadeLib.Commands.DTOs.Accomodations;

public record UploadAccomdationImageCommand(Guid UserId, Guid AccomodationId, Stream ImageStream, string Extension);
