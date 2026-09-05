using BookingService.DomainLib.Entities;

namespace BookingService.ApplicationLib.Repositories;

public interface IBookingRepository
{
    Task AddAsync(Booking booking);

    Task SaveAsync();
}
