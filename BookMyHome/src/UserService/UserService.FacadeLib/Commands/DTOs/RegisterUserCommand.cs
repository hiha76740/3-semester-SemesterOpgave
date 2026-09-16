namespace UserService.FacadeLib.Commands.DTOs;

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
