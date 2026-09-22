namespace UserService.FacadeLib.Commands.DTOs;

public record RefreshTokenCommand(string ExpiredAccessToken, string RefreshToken);
