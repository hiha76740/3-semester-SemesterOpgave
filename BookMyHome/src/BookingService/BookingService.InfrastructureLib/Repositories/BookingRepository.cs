using BookingService.ApplicationLib.Repositories;
using BookingService.DomainLib.Entities;

namespace BookingService.InfrastructureLib.Repositories;

public class BookingRepository : IBookingRepository
{
    Task IBookingRepository.AddAsync(Booking booking)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Booking>> IBookingRepository.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<Booking> IBookingRepository.GetBookingByIdAsync(BookingId id)
    {
        throw new NotImplementedException();
    }

    Task IBookingRepository.SaveAsync()
    {
        throw new NotImplementedException();
    }
}
