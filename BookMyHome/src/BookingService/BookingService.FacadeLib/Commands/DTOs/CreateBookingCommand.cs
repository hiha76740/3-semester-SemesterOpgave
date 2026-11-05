namespace BookingService.FacadeLib.Commands.DTOs;

public record CreateBookingCommand(Guid GuestId, Guid AccomodationId,Guid ListingId, DateOnly StartDate, DateOnly EndDate, decimal Price);
