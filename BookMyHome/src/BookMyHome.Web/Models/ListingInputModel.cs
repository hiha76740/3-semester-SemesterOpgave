using Microsoft.AspNetCore.Components.Forms;

namespace BookMyHome.Web.Models;

/// <summary>
/// 
/// </summary>
public class ListingInputModel
{
    /// <summary>
    /// 
    /// </summary>
    public string ListingName { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public Guid ListingId { get; set; } = Guid.Empty;
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
    public string HouseRules { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string AccomodationType { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public bool Status { get; set; } = true;
    /// <summary>
    /// 
    /// </summary>
    public byte[] RowVersion { get; set; } = [];
    /// <summary>
    /// 
    /// </summary>
    public string? ImageUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public IBrowserFile? ImageFile { get; set; }

}
