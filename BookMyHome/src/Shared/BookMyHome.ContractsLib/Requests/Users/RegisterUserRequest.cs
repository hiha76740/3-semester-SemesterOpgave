namespace BookMyHome.ContractsLib.Requests.Users;

public record RegisterUserRequest(
    string FirstName,
    string LastName,
    DateOnly Birthdate,
    string Street,
    string PostalCode,
    string City,
    string PhoneNumber,
    string Email,
    string Password
    );
