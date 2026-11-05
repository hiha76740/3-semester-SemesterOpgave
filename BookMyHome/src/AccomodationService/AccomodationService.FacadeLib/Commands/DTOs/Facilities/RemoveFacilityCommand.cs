namespace AccomodationService.FacadeLib.Commands.DTOs.Facilities;

public record RemoveFacilityCommand(Guid HostId, Guid AccomodationId, Guid FacilityId);
