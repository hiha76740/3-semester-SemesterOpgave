using BookingService.DomainLib.Entities;
using BookingService.DomainLib.Enums;
using BookingService.DomainLib.ValueObjects;
using BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.DomainLib.Tests;

public class BookingTests
{
    private static readonly AccomodationId s_accomodationId = new(Guid.Parse("4504e34a-67a5-4cba-b029-8eb0b453b80d"));
    private static readonly GuestId s_guestId = new(Guid.Parse("4504e34a-67a5-4cba-b030-8eb0b693b80d"));
    private static readonly ListingId s_listingId = new(Guid.Parse("4504e34a-67a5-4cba-b040-8eb0b693b80d"));
    private static readonly decimal s_price = 500m;

    private static readonly DateOnly s_startDate = DateOnly.FromDateTime(DateTime.UtcNow);
    private static readonly DateOnly s_endDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5));


    private static Booking CreateBookingWithNoOverlap(
        AccomodationId? accomodationId = null,
        GuestId? guestId = null,
        ListingId? listingId = null,
        decimal? price = null,
        DateOnly? startDate = null,
        DateOnly? endDate = null
        )
    {
        return Booking.Create(
            guestId ?? s_guestId,
            accomodationId ?? s_accomodationId,
            listingId ?? s_listingId,
            startDate ?? s_startDate,
            endDate ?? s_endDate,
            price ?? s_price
            );
    }

    [Fact]
    public void Create_GivenValidBooking_SetsStatusToBooked()
    {
        // Arrange
        var expected = BookingStatus.Booked;

        // Act
        var booking = CreateBookingWithNoOverlap();

        // Assert
        Assert.Equal(expected, booking.Status);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(100)]
    public void Create_GivenValidPrice_SetsPrice(decimal price)
    {
        // Act
        var booking = CreateBookingWithNoOverlap(price: price);

        // Assert
        Assert.Equal(booking.Price, price);
    }

    [Fact]
    public void Create_GivenNegativePrice_ThrowsException()
    {
        // Arrange
        var price = -10m;

        // Act & Assert
        Assert.Throws<DomainException>(() => CreateBookingWithNoOverlap(price: price));
    }

    [Fact]
    public void CancelBooking_GivenValidBooking_SetsStatusCancelled()
    {
        // Arrange
        var booking = CreateBookingWithNoOverlap();

        var expected = BookingStatus.Cancelled;

        // Act
        booking.CancelBooking();

        // Assert
        Assert.Equal(expected, booking.Status);
    }

    [Fact]
    public void CancelBooking_GivenAlreadyCancelled_ThrowsException()
    {
        // Arrange
        var booking = CreateBookingWithNoOverlap();
        booking.CancelBooking();

        // Act & Assert
        Assert.Throws<DomainException>(booking.CancelBooking);
    }


}
