using BookMyHome.ContractsLib.Requests.Users;
using Microsoft.AspNetCore.Identity.Data;
using UserService.FacadeLib.Commands.DTOs;

namespace UserService.Api.Mapper;

public static class UserMapper
{
    public static RegisterUserCommand AsCommand(this RegisterUserRequest request)
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
}
