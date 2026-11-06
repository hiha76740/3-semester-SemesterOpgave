namespace AccomodationService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="AccomodationId"></param>
/// <param name="Title"></param>
/// <param name="Street"></param>
/// <param name="PostalCode"></param>
/// <param name="City"></param>
/// <param name="Country"></param>
/// <param name="Facilities"></param>
/// <param name="Status"></param>
/// <param name="ImageFileName"></param>
public record AccomodationDto(
    Guid AccomodationId,
    string Title,
    string Street,
    string PostalCode,
    string City,
    string Country,
    IReadOnlyList<FacilityDto> Facilities,
    string Status,
    string? ImageFileName
    );
