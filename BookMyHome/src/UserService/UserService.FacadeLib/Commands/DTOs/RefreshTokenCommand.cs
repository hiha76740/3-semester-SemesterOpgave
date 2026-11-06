namespace UserService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="ExpiredAccessToken"></param>
/// <param name="RefreshToken"></param>
public record RefreshTokenCommand(string ExpiredAccessToken, string RefreshToken);
