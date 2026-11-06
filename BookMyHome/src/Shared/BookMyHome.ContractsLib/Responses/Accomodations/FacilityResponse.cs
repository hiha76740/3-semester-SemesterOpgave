namespace BookMyHome.ContractsLib.Responses.Accomodations;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
public record FacilityResponse(
    Guid Id,
    string Name
    );
