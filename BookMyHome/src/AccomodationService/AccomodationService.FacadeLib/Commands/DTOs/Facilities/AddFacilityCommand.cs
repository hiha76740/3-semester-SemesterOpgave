namespace AccomodationService.FacadeLib.Commands.DTOs.Facilities;

/// <summary>
/// 
/// </summary>
/// <param name="HostId"></param>
/// <param name="AccomodationId"></param>
/// <param name="FacilityId"></param>
public record AddFacilityCommand(Guid HostId, Guid AccomodationId, Guid FacilityId);
