namespace UserService.FacadeLib.Queries.DTOs;

/// <summary>
/// 
/// </summary>
/// <param name="Id"></param>
/// <param name="Firstname"></param>
/// <param name="Lastname"></param>
/// <param name="Birthdate"></param>
/// <param name="Street"></param>
/// <param name="PostalCode"></param>
/// <param name="City"></param>
/// <param name="PhoneNumber"></param>
/// <param name="Email"></param>
/// <param name="Username"></param>
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
