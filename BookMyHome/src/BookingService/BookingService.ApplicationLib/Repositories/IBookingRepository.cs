using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;

namespace BookingService.ApplicationLib.Repositories;

public interface IBookingRepository
{
    Task<Booking?> GetBookingByIdAsync(BookingId id);

    Task<bool> HasOverlapingBookingAsync(AccomodationId  accomodationId, DateOnly startDate, DateOnly endDate);

    Task CreateAsync(Booking booking);

    Task SaveAsync();
}
