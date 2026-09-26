using BookingService.ApplicationLib.Repositories;
using BookingService.DomainLib.Entities;
using BookingService.DomainLib.Enums;
using BookingService.DomainLib.ValueObjects;
using BookingService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookingService.InfrastructureLib.Repositories;

public class BookingRepository(BookingDbContext db) : IBookingRepository
{
    async Task IBookingRepository.CreateAsync(Booking booking)
    {
        await db.Bookings.AddAsync(booking);
    }

    async Task<Booking?> IBookingRepository.GetBookingByIdAsync(BookingId id)
    {
        var output = await db.Bookings.FirstOrDefaultAsync(b => b.Id == id);

        return output;
    }

    async Task<bool> IBookingRepository.HasOverlapingBookingAsync(AccomodationId accomodationId, DateOnly startDate, DateOnly endDate)
    {
        return await db.Bookings
            .AnyAsync(eb => 
                      eb.AccomodationId == accomodationId &&
                      eb.Status == BookingStatus.Booked &&
                      startDate < eb.Period.EndDate &&
                      eb.Period.StartDate < endDate
            );
    }

    async Task IBookingRepository.SaveAsync()
    {
        await db.SaveChangesAsync();
    }
}
