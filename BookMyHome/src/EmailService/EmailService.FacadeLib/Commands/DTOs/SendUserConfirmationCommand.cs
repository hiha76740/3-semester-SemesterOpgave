namespace EmailService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Firstname"></param>
/// <param name="Lastname"></param>
/// <param name="Email"></param>
/// <param name="Username"></param>
public record SendUserConfirmationCommand(string Firstname, string Lastname, string Email, string Username);
