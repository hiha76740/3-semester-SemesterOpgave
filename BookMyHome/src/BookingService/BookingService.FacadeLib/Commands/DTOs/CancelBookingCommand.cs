namespace BookingService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="BookingId"></param>
/// <param name="UserId"></param>
public record CancelBookingCommand(Guid BookingId, Guid UserId);
