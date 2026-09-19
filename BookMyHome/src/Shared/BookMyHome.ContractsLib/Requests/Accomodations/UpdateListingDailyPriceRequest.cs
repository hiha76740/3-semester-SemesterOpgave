namespace BookMyHome.ContractsLib.Requests.Accomodations;

public record UpdateListingDailyPriceRequest(Guid AccomodationId, Guid ListingId, decimal Price);
