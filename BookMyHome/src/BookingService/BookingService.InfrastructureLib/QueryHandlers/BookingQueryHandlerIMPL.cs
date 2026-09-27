using BookingService.DomainLib.Entities;
using BookingService.DomainLib.Enums;
using BookingService.DomainLib.ValueObjects;
using BookingService.FacadeLib.Queries.DTOs;
using BookingService.FacadeLib.Queries.Interfaces;
using BookingService.InfrastructureLib.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BookingService.InfrastructureLib.QueryHandlers;

public class BookingQueryHandlerIMPL(BookingDbContext db) : IBookingQueries
{
    async Task<bool> IBookingQueries.Checkavailability(Guid accomodationId, DateOnly startDate, DateOnly endDate)
    {
        var id = new AccomodationId(accomodationId);

        return await db.Bookings
            .AnyAsync(eb =>
                      eb.AccomodationId == id &&
                      eb.Status == BookingStatus.Booked &&
                      startDate < eb.Period.EndDate &&
                      eb.Period.StartDate < endDate
            );
    }

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
        var bookingId = new BookingId(Id);

        return await db.Bookings
            .AsNoTracking()
            .Where(b => b.Id == bookingId)
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
