namespace BookMyHome.ContractsLib.Responses.Accomodations;

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
/// <param name="ImageUrl"></param>
public record AccomodationResponse(
    Guid AccomodationId,
    string Title,
    string Street,
    string PostalCode,
    string City,
    string Country,
    IReadOnlyList<FacilityResponse> Facilities,
    string Status,
    String? ImageUrl
    );
