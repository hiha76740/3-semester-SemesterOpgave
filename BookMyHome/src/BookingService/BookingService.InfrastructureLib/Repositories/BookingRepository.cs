using BookingService.ApplicationLib.Repositories;
using BookingService.DomainLib.Entities;
using BookingService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookingService.InfrastructureLib.Repositories;

public class BookingRepository(BookingDbContext db) : IBookingRepository
{
    async Task IBookingRepository.AddAsync(Booking booking)
    {
        await db.Bookings.AddAsync(booking);
    }

    async Task<IEnumerable<Booking>> IBookingRepository.GetAllAsync()
    {
        var output = await db.Bookings.ToListAsync();

        return output;
    }

    async Task<Booking?> IBookingRepository.GetBookingByIdAsync(BookingId id)
    {
        var output = await db.Bookings.FirstOrDefaultAsync(b => b.Id == id);

        return output;
    }

    async Task IBookingRepository.SaveAsync()
    {
        await db.SaveChangesAsync();
    }
}
