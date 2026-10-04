namespace BookMyHome.ContractsLib.Responses.Accomodations;

public record AccomodationResponse(
    Guid AccomodationId,
    string Title,
    string Street,
    string PostalCode,
    string City,
    string Country,
    IReadOnlyList<FacilityResponse> Facilities,
    string Status,
    string? ImageFileName
    );
