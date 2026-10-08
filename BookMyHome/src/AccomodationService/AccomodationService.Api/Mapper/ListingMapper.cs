using AccomodationService.FacadeLib.Commands.DTOs.Listings;
using AccomodationService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace AccomodationService.Api.Mapper;

public static class ListingMapper
{
    public static ListingResponse AsReponse(this ListingDto dto, string? url)
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
            dto.Country,
            dto.Status,
            dto.Facilities,
            dto.RowVersion,
            url
            );

        return output;
    }

    public static CreateListingCommand AsCreateListingCommand(this CreateListingRequest request, Guid hostId, Stream? imageStream = null, string? extension = null)
    {
        var output = new CreateListingCommand(
            hostId,
            request.AccomodationId,
            request.ListingName,
            request.DailyPrice,
            request.HouseRules,
            request.AccomodationType,
            imageStream,
            extension
            );

        return output;
    }

    public static AccomodationSummaryResponse AsListingSummaryResponse(this AccomodationSummaryDto dto)
    {
        var output = new AccomodationSummaryResponse(
            dto.ListingName,
            dto.ListingType,
            dto.City,
            dto.Country
            );

        return output;
    }
}
