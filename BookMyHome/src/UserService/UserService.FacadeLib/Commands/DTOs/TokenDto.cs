namespace UserService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="AccessToken"></param>
/// <param name="RefreshToken"></param>
public record TokenDto(string AccessToken, string RefreshToken);
