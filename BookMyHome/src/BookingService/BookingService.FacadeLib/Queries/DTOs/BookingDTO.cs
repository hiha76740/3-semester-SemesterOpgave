namespace BookingService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="BookingNumber"></param>
/// <param name="GuestId"></param>
/// <param name="AccomodationId"></param>
/// <param name="ListingId"></param>
/// <param name="StartDate"></param>
/// <param name="EndDate"></param>
/// <param name="Price"></param>
/// <param name="Status"></param>
public record BookingDTO(Guid Id, int BookingNumber, Guid GuestId, Guid AccomodationId, Guid ListingId, DateOnly StartDate, DateOnly EndDate, decimal Price, string Status);
