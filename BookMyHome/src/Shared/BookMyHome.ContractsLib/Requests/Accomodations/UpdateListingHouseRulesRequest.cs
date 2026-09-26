namespace BookMyHome.ContractsLib.Requests.Accomodations;

public record UpdateListingHouseRulesRequest(string HouseRules, byte[] RowVersion);
