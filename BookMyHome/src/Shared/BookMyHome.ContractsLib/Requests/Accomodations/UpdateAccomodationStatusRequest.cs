namespace BookMyHome.ContractsLib.Requests.Accomodations;

public record UpdateAccomodationStatusRequest(Guid AccomodationId, string Status);
