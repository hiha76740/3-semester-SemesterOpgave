namespace BookMyHome.ContractsLib.Responses.Authentication;

public record AuthUserResponse(Guid Id, string Username, string Firstname, string Lastname);
