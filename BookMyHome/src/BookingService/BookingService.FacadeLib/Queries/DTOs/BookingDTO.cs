namespace BookingService.FacadeLib.Queries.DTOs;

public record BookingDTO(Guid Id, Guid GuestId, Guid AccomodationId, DateOnly StartDate, DateOnly EndDate, decimal Price);
