using BookMyHome.SharedKernelLib.Exceptions;

namespace BookingService.DomainLib.ValueObjects;

/// <summary>
/// 
/// </summary>
public record BookingPeriod
{
    /// <summary>
    /// 
    /// </summary>
    public DateOnly StartDate { get; init; }
    /// <summary>
    /// 
    /// </summary>
    public DateOnly EndDate { get; init; }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <exception cref="DomainException"></exception>
    public BookingPeriod(DateOnly startDate, DateOnly endDate)
    {
        if (startDate >= endDate)
            throw new DomainException("End date can not be before or same as start date");

        StartDate = startDate;
        EndDate = endDate;
    }
}
