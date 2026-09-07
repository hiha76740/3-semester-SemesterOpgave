using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;

namespace BookingService.DomainLib.Tests;

internal class BookingTests
{
    private readonly static AccomodationId AccomodationId = new (Guid.Parse("4504e34a-67a5-4cba-b029-8eb0b453b80d"));
    private readonly static GuestId GuestId = new (Guid.Parse("4504e34a-67a5-4cba-b029-8eb0b693b80d"));       
    private readonly static decimal Price = 500m;

    private static Booking BookingWithNoOverlap(
        AccomodationId? accomodationId = null,
        GuestId? guestId = null,
        decimal? price = null,
        DateOnly? startDate = null,
        DateOnly? endDate = null
        )
    {
        return Booking.Create(
            guestId ?? GuestId,
            accomodationId ?? AccomodationId,
            startDate ?? DateOnly.FromDateTime(DateTime.UtcNow),
            endDate ?? DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1)),
            price ?? Price,
            []
            );
    }
}
