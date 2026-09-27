namespace AccomodationService.FacadeLib.Queries.Interfaces;

public interface IBookingService
{
    Task<bool> IsAvailableAsync(
        Guid accomodationId,
        DateOnly start,
        DateOnly end);
}
