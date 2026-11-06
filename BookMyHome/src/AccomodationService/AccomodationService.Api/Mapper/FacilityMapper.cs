using AccomodationService.FacadeLib.Commands.DTOs.Facilities;
using AccomodationService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace AccomodationService.Api.Mapper;

/// <summary>
/// 
/// </summary>
public static class FacilityMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="accomodationId"></param>
    /// <param name="hostId"></param>
    /// <returns></returns>
    public static AddFacilityCommand AsAddCommand(this AddFacilityRequest request, Guid accomodationId, Guid hostId)
    {
        var output = new AddFacilityCommand(
            hostId,
            accomodationId,
            request.FacilityId);

        return output;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="accomdationId"></param>
    /// <param name="hostId"></param>
    /// <returns></returns>
    public static RemoveFacilityCommand AsRemoveCommand(this RemoveFacilityRequest request, Guid accomdationId, Guid hostId)
    {
        var output = new RemoveFacilityCommand(
            hostId,
            accomdationId,
            request.FacilityId
            );

        return output;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static FacilityResponse AsResponse(this FacilityDto dto)
    {
        var output = new FacilityResponse(
            dto.Id,
            dto.Name
            );

        return output;
    }
}
