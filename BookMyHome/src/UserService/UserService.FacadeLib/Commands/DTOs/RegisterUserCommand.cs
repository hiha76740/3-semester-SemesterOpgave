namespace UserService.FacadeLib.Commands.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="Birthdate"></param>
/// <param name="Street"></param>
/// <param name="PostalCode"></param>
/// <param name="City"></param>
/// <param name="PhoneNumber"></param>
/// <param name="Email"></param>
/// <param name="Password"></param>
/// <param name="Role"></param>
public record RegisterUserCommand(
    string FirstName,
    string LastName,
    DateOnly Birthdate,
    string Street,
    string PostalCode,
    string City,
    string PhoneNumber,
    string Email,
    string Password,
    string Role
    );
