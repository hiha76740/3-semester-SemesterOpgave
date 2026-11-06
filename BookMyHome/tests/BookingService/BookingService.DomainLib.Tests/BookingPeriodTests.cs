using BookingService.DomainLib.ValueObjects;
using BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.DomainLib.Tests;

public class BookingPeriodTests
{
    private static readonly DateOnly s_startDate = DateOnly.FromDateTime(DateTime.UtcNow);
    private static readonly DateOnly s_endDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(5));

    private static BookingPeriod CreateBookingPeriod(
        DateOnly? start = null,
        DateOnly? end = null
        )
    {
        return new BookingPeriod(
            start ?? s_startDate,
            end ?? s_endDate
            );
    }

    [Fact]
    public void Create_GivenValidBookingPeriod_SetsStartAndEndDate()
    {
        // Arrange
        var expected = new BookingPeriod(s_startDate, s_endDate);

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
        var endDate = s_startDate.AddDays(end);

        // Act & Assert
        Assert.Throws<DomainException>(() => CreateBookingPeriod(s_startDate, endDate));

    }
}
