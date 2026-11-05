namespace UserService.FacadeLib.Queries.DTOs;

public record UserDto(
    Guid Id,
    string Firstname,
    string Lastname,
    DateOnly Birthdate,
    string Street,
    string PostalCode,
    string City,
    string PhoneNumber,
    string Email,
    string Username
    );
