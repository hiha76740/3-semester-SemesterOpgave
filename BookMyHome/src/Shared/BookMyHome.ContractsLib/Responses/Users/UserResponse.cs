namespace BookMyHome.ContractsLib.Responses.Users;

public record UserResponse(
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
