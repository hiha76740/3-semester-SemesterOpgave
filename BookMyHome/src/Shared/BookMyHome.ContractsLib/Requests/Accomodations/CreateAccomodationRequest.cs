namespace BookMyHome.ContractsLib.Requests.Accomodations;

/// <summary>
/// 
/// </summary>
/// <param name="Title"></param>
/// <param name="Street"></param>
/// <param name="PostalCode"></param>
/// <param name="City"></param>
/// <param name="Country"></param>
/// <param name="FacilitiesIds"></param>
public record CreateAccomodationRequest(
    string Title,
    string Street,
    string PostalCode,
    string City,
    string Country,
    List<Guid> FacilitiesIds
    );
