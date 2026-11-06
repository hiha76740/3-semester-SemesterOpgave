namespace BookMyHome.ContractsLib.Events;

/// <summary>
/// 
/// </summary>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="Email"></param>
/// <param name="Username"></param>
public record UserRegisteredIntegrationEvent(string FirstName, string LastName, string Email, string Username);
