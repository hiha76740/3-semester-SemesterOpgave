namespace BookMyHome.ContractsLib.Requests.Accomodations;

/// <summary>
/// 
/// </summary>
/// <param name="Status"></param>
/// <param name="FacilitiesIds"></param>
public record UpdateAccomodationRequest(string Status, List<Guid> FacilitiesIds);
