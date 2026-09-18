namespace BookMyHome.ContractsLib.Requests.Accomodations;

public record CreateAccomodationRequest(string Title, string Street, string PostalCode, string City);
