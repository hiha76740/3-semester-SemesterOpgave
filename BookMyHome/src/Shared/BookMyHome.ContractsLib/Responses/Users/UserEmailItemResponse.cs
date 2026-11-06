namespace BookMyHome.ContractsLib.Responses.Users;

/// <summary>
/// 
/// </summary>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="Email"></param>
public record UserEmailItemResponse(string FirstName, string LastName, string Email);
