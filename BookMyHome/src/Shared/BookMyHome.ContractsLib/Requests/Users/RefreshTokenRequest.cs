namespace BookMyHome.ContractsLib.Requests.Users;

/// <summary>
/// 
/// </summary>
/// <param name="ExpiredAccessToken"></param>
/// <param name="RefreshToken"></param>
public record RefreshTokenRequest(string ExpiredAccessToken, string RefreshToken);
