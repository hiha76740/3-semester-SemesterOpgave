namespace AccomodationService.FacadeLib.Commands.DTOs.Facilities;

public record AddFacilityCommand(Guid HostId, Guid AccomodationId,Guid FacilityId);
