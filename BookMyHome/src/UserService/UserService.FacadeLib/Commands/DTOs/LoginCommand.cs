namespace UserService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Username"></param>
/// <param name="Password"></param>
public record LoginCommand(string Username, string Password);
