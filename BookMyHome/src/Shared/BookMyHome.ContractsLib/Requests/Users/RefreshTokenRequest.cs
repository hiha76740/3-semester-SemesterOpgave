namespace BookMyHome.ContractsLib.Requests.Users;

public record RefreshTokenRequest(string ExpiredAccessToken, string RefreshToken);
