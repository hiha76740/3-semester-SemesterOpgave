using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;
using AccomodationService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;

namespace AccomodationService.Api.Mapper;

/// <summary>
/// 
/// </summary>
public static class AccomodationMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public static AccomodationResponse AsResponse(this AccomodationDto dto, string? url)
    {
        var output = new AccomodationResponse(
            dto.AccomodationId,
            dto.Title,
            dto.Street,
            dto.PostalCode,
            dto.City,
            dto.Country,
            dto.Facilities.Select(f => new FacilityResponse(f.Id, f.Name)).ToList(),
            dto.Status,
            url
            );

        return output;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="id"></param>
    /// <param name="imageStream"></param>
    /// <param name="extension"></param>
    /// <returns></returns>
    public static CreateAccomodationCommand CreateRequestAsCommand(this CreateAccomodationRequest request, Guid id, Stream? imageStream = null, string? extension = null)
    {
        var output = new CreateAccomodationCommand(
            id,
            request.Title,
            request.Street,
            request.PostalCode,
            request.City,
            request.Country,
            request.FacilitiesIds,
            imageStream,
            extension
            );

        return output;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static AccomodationTypeResponse AsAccomodationTypeResponse(this AccomodationTypeDto dto)
    {
        var output = new AccomodationTypeResponse(
            dto.Type
            );

        return output;
    }
}
