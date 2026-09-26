using AccomodationService.FacadeLib.Commands.DTOs.Facilities;
using BookMyHome.ContractsLib.Requests.Accomodations;

namespace AccomodationService.Api.Mapper;

public static class FacilityMapper
{
    public static AddFacilityCommand AsAddCommand(this AddFacilityRequest request)
    {
        var output = new AddFacilityCommand(
            request.AccomodationId,
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
}
