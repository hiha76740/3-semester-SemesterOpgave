namespace BookMyHome.ContractsLib.Responses.Authentication;

/// <summary>
/// 
/// </summary>
/// <param name="AccessToken"></param>
/// <param name="RefreshToken"></param>
public record TokenResponse(
    string AccessToken,
    string RefreshToken
    );
