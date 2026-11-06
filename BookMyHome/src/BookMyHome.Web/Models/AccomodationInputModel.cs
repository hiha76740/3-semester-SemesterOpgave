using Microsoft.AspNetCore.Components.Forms;

namespace BookMyHome.Web.Models;

/// <summary>
/// 
/// </summary>
public class AccomodationInputModel
{
    /// <summary>
    /// 
    /// </summary>
    public Guid AccomodationId { get; set; } = Guid.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string Street { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string PostalCode { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string City { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string Country { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public bool Status { get; set; } = true;
    /// <summary>
    /// 
    /// </summary>
    public string? ImageUrl { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public IBrowserFile? ImageFile { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public List<Guid> FacilitiesIds { get; set; } = [];
}
