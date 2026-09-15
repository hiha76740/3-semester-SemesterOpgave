using AccomodationService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace AccomodationService.Api.Mapper;

public static class ListingMapper
{
    public static ListingResponse AsReponse(this ListingDto dto)
    {
        var output = new ListingResponse(
            dto.ListingId,
            dto.AccomodationId,
            dto.ListingName,
            dto.DailyPrice,
            dto.HouseRules,
            dto.AccomodationType
            );

        return output;
    }
}
