namespace BookingService.FacadeLib.Commands.DTOs;

public record CancelBookingCommand(Guid BookingId, Guid UserId); 
