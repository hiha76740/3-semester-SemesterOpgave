using Shared.BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.DomainLib.ValueObjects;

public record BookingPeriod
{
    public DateOnly StartDate { get; init; }

    public DateOnly EndDate { get; init; }

    public BookingPeriod(DateOnly startDate, DateOnly endDate)
    {
        if (startDate <= endDate)
            throw new DomainException("End date can not be in the past or same as start date");

        StartDate = startDate;
        EndDate = endDate;
    }
}
