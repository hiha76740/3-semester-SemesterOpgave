namespace AccomodationService.FacadeLib.Queries.DTOs;

public record AccomodationDto(
    Guid AccomodationId,
    string Title,
    string Street,
    string PostalCode,
    string City,
    string Country,
    IReadOnlyList<FacilityDto> Facilities,
    string Status
    );
