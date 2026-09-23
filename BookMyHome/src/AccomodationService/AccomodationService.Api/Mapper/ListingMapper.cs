using AccomodationService.FacadeLib.Commands.DTOs;
using AccomodationService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Requests.Accomodations;
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
            dto.AccomodationType,
            dto.Street,
            dto.PostalCode,
            dto.City,
            dto.Country
            );

        return output;
    }

    public static CreateListingCommand AsCreateListingCommand(this CreateListingRequest request, Guid hostId)
    {
        var output = new CreateListingCommand(
            hostId,
            request.AccomodationId,
            request.ListingName,
            request.DailyPrice,
            request.HouseRules,
            request.AccomodationType
            );

        return output;
    }
}
