namespace BookMyHome.ContractsLib.Requests.Accomodations;

public record CreateAccomodationRequest(Guid HostId, string Title);
