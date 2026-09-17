using BookMyHome.ContractsLib.Requests.Users;
using UserService.FacadeLib.Commands.DTOs;

namespace UserService.Api.Mapper;

public static class UserMapper
{
    public static RegisterUserCommand AsRegisterCommand(this RegisterUserRequest request)
    {
        var output = new RegisterUserCommand(
            request.FirstName,
            request.LastName,
            request.Birthdate,
            request.Street,
            request.PostalCode,
            request.City,
            request.PhoneNumber,
            request.Email,
            request.Password,
            request.Role
            );

        return output;
    }

    public static LoginCommand AsLoginCommand(this LoginRequest request)
    {
        var output = new LoginCommand(
            request.Username,
            request.Password
            );

        return output;
    }
}
