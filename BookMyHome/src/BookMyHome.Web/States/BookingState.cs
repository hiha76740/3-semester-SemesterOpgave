namespace BookMyHome.Web.States;

/// <summary>
/// 
/// </summary>
public class BookingState
{
    /// <summary>
    /// 
    /// </summary>
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    /// <summary>
    /// 
    /// </summary>
    public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(7));
    /// <summary>
    /// 
    /// </summary>
    public Guid AccomodationId { get; set; } = Guid.Empty;
    /// <summary>
    /// 
    /// </summary>
    public decimal DailyPrice { get; set; } = 0;
    /// <summary>
    /// 
    /// </summary>
    public decimal TotalPrice => (EndDate.DayOfYear - StartDate.DayOfYear) * DailyPrice;
    /// <summary>
    /// 
    /// </summary>
    public void Clear()
    {
        StartDate = DateOnly.FromDateTime(DateTime.Today);
        EndDate = DateOnly.FromDateTime(DateTime.Today.AddDays(7));
        AccomodationId = Guid.Empty;
        DailyPrice = 0;
    }
}
