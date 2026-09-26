using BookingService.DomainLib.Entities;
using BookingService.DomainLib.Enums;
using BookingService.DomainLib.ValueObjects;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.DomainLib.Tests;

public class BookingTests
{
    private readonly static AccomodationId AccomodationId = new(Guid.Parse("4504e34a-67a5-4cba-b029-8eb0b453b80d"));
    private readonly static GuestId GuestId = new(Guid.Parse("4504e34a-67a5-4cba-b029-8eb0b693b80d"));
    private readonly static decimal Price = 500m;

    private readonly static DateOnly StartDate = DateOnly.FromDateTime(DateTime.UtcNow);
    private readonly static DateOnly EndDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5));


    private static Booking CreateBookingWithNoOverlap(
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
            startDate ?? StartDate,
            endDate ?? EndDate,
            price ?? Price
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
        decimal price = -10m;

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
        Assert.Throws<DomainException>(() => booking.CancelBooking());
    }


}
