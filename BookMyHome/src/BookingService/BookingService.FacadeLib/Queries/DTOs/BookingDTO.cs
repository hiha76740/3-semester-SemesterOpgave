namespace BookingService.FacadeLib.Queries.DTOs;

public record BookingDTO(Guid Id,int BookingNumber, Guid GuestId, Guid AccomodationId,Guid ListingId, DateOnly StartDate, DateOnly EndDate, decimal Price, string Status);
