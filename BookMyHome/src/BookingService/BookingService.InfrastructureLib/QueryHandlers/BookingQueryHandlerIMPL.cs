using BookingService.FacadeLib.Queries.DTOs;
using BookingService.FacadeLib.Queries.Interfaces;
using BookingService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookingService.InfrastructureLib.QueryHandlers;

public class BookingQueryHandlerIMPL(BookingDbContext db) : IBookingQueries
{
    async Task<IReadOnlyList<BookingDTO>> IBookingQueries.GetAllAsync()
    {
        return await db.Bookings
            .AsNoTracking()
            .Select(b => new BookingDTO(
                b.Id.Value,
                b.GuestId.Value,
                b.AccomodationId.Value,
                b.Period.StartDate,
                b.Period.EndDate,
                b.Price
                ))
            .ToListAsync();
    }

    async Task<BookingDTO?> IBookingQueries.GetBookingByIdAsync(Guid Id)
    {
        return await db.Bookings
            .AsNoTracking()
            .Where(b => b.Id.Value == Id)
            .Select(b => new BookingDTO(
                b.Id.Value,
                b.GuestId.Value,
                b.AccomodationId.Value,
                b.Period.StartDate,
                b.Period.EndDate,
                b.Price
                ))
            .FirstOrDefaultAsync();
    }
}
