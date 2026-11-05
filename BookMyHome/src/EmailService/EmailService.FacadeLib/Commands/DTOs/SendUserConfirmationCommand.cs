namespace EmailService.FacadeLib.Commands.DTOs;

public record SendUserConfirmationCommand(string Firstname, string Lastname, string Email, string Username);
