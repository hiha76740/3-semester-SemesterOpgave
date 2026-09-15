using BookingService.DomainLib.Entities;

namespace BookingService.ApplicationLib.Repositories;

public interface IBookingRepository
{
    Task<Booking?> GetBookingByIdAsync(BookingId id);

    Task<IEnumerable<Booking>> GetAllAsync();

    Task CreateAsync(Booking booking);

    Task SaveAsync();
}
