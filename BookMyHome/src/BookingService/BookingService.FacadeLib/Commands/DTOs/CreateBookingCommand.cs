namespace BookingService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="GuestId"></param>
/// <param name="AccomodationId"></param>
/// <param name="ListingId"></param>
/// <param name="StartDate"></param>
/// <param name="EndDate"></param>
/// <param name="Price"></param>
public record CreateBookingCommand(Guid GuestId, Guid AccomodationId, Guid ListingId, DateOnly StartDate, DateOnly EndDate, decimal Price);
