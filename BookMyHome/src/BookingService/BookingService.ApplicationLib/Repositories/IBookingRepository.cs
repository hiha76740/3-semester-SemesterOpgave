using BookingService.DomainLib.Entities;

namespace BookingService.ApplicationLib.Repositories;

public interface IBookingRepository
{
    Task<Booking> GetBookingByIdAsync(BookingId id);

    Task AddAsync(Booking booking);

    Task SaveAsync();
}
