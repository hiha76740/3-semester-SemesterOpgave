namespace BookMyHome.ContractsLib.Events;

public record UserRegisteredIntegrationEvent(string FirstName, string LastName, string Email, string Username);
