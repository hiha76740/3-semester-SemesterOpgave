namespace EmailService.FacadeLib.Commands.DTOs;

public record SendBookingConfirmationCommand(
    Guid BookingId,
    DateOnly StartDate, 
    DateOnly EndDate, 
    decimal Price,
    string ListingName,
    decimal DailyPrice,
    string HouseRules,
    string AccomodationType,
    string Street,
    string PostalCode,
    string City,
    string Country,
    string[] Facilities,
    string? ImageUrl,
    string UserFirstName,
    string UserLastName,
    string UserEmail
    );
