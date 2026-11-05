namespace BookMyHome.ContractsLib.Requests.Accomodations;

public record UpdateAccomodationRequest(string Status, List<Guid>FacilitiesIds);
