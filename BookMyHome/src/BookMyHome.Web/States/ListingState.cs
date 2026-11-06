namespace BookMyHome.Web.States;

/// <summary>
/// 
/// </summary>
public class ListingState
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = string.Empty;
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
    public string Type { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="listingName"></param>
    /// <param name="street"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <param name="country"></param>
    /// <param name="type"></param>
    public void SetState(Guid id, string listingName, string street, string postalCode, string city, string country, string type)
    {
        Id = id;
        Name = listingName;
        Street = street;
        PostalCode = postalCode;
        City = city;
        Country = country;
        Type = type;
    }
    /// <summary>
    /// 
    /// </summary>
    public void Clear()
    {
        Name = string.Empty;
        Street = string.Empty;
        PostalCode = string.Empty;
        City = string.Empty;
        Country = string.Empty;
        Type = string.Empty;
    }

}
