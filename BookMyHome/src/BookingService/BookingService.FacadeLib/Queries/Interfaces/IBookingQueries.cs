using BookingService.FacadeLib.Queries.DTOs;

namespace BookingService.FacadeLib.Queries.Interfaces;

public interface IBookingQueries
{
    Task<IReadOnlyList<BookingDTO>> GetAllAsync();

    Task<BookingDTO?> GetBookingByIdAsync(Guid Id);

    Task<bool> Checkavailability(Guid accomodationId, DateOnly startDate, DateOnly endDate);

    Task<IReadOnlyList<BookingSummaryDto>> GetAllUserBookings(Guid userId);

    Task<IReadOnlyList<BookingSummaryDto>> GetAllAccomdationBookings(Guid accomdationId);
}
