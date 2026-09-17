namespace BookMyHome.ContractsLib.Requests.Users;

public record RefreshTokenRequest(Guid UserId, string RefreshToken);
