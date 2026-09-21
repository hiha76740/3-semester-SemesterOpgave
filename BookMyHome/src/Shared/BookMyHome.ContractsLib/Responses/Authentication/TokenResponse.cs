namespace BookMyHome.ContractsLib.Responses.Authentication;

public record TokenResponse(string AccessToken, string RefreshToken);
