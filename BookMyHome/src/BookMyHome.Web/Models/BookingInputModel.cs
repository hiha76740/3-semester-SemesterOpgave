namespace BookMyHome.Web.Models;

/// <summary>
/// 
/// </summary>
public class BookingInputModel
{
    /// <summary>
    /// 
    /// </summary>
    public Guid GuestId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid AccomodationId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Guid ListingId { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateOnly StartDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateOnly EndDate { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public decimal Price { get; set; }
}
