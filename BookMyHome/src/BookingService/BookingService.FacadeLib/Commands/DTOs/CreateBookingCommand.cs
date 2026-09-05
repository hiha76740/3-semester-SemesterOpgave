namespace BookingService.FacadeLib.Commands.DTOs;

public record CreateBookingCommand(Guid GuestId, Guid AccomodationId, DateOnly StartDate, DateOnly EndDate, decimal Price);
