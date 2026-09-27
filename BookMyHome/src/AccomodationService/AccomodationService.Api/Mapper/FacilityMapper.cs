using AccomodationService.FacadeLib.Commands.DTOs.Facilities;
using AccomodationService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace AccomodationService.Api.Mapper;

public static class FacilityMapper
{
    public static AddFacilityCommand AsAddCommand(this AddFacilityRequest request, Guid accomodationId)
    {
        var output = new AddFacilityCommand(
            accomodationId,
            request.FacilityId);

        return output;
    }

    public static RemoveFacilityCommand AsRemoveCommand(this RemoveFacilityRequest request)
    {
        var output = new RemoveFacilityCommand(
            request.AccomodationId,
            request.FacilityId
            );

        return output;
    }

    public static FacilityResponse AsResponse(this FacilityDto dto)
    {
        var output = new FacilityResponse(
            dto.Id,
            dto.Name
            );

        return output;
    }
}
