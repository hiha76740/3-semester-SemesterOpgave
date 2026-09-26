namespace BookMyHome.ContractsLib.Requests.Accomodations;

public record UpdateListingDailyPriceRequest(decimal Price, byte[] RowVersion);
