namespace BookMyHome.ContractsLib.Events;

public record BookingPlacedIntegrationEvent(Guid BookingId, DateOnly StartDate, DateOnly EndDate, decimal Price, string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string Street,
    string PostalCode,
    string City,
    string Country,
    string[] Facilities,
    string? ImageUrl, 
    string FirstName,
    string LastName,
    string Email
    );
