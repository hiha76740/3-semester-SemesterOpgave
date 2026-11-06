namespace BookMyHome.Web.Models;

/// <summary>
/// 
/// </summary>
public class UserInputModel
{
    /// <summary>
    /// 
    /// </summary>
    public Guid Id { get; set; } = Guid.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string FirstName { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string Email { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public DateOnly Birthdate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
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
    public string Password { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string RepeatPassword { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string AccessRole { get; set; } = string.Empty;
    /// <summary>
    /// 
    /// </summary>
    public string Username { get; set; } = string.Empty;
}
