using BookingService.DomainLib.ValueObjects;
using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.DomainLib.Tests;

public class BookingPeriodTests
{
    private readonly static DateOnly StartDate = DateOnly.FromDateTime(DateTime.UtcNow);
    private readonly static DateOnly EndDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5));

    private static BookingPeriod CreateBookingPeriod(
        DateOnly? start = null,
        DateOnly? end = null
        )
    {
        return new BookingPeriod(
            start ?? StartDate,
            end ?? EndDate
            );
    }

    [Fact]
    public void Create_GivenValidBookingPeriod_SetsStartAndEndDate()
    {
        // Arrange
        var expected = new BookingPeriod(StartDate, EndDate);

        // Act
        var period = CreateBookingPeriod();

        // Assert
        Assert.Equal(expected, period);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]

    public void Create_GivenInvalidEndDate_ThrowsException(int end)
    {
        // Arrange
        var endDate = StartDate.AddDays(end);

        // Act & Assert
        Assert.Throws<DomainException>(() => CreateBookingPeriod(StartDate, endDate));
        
    }
}
