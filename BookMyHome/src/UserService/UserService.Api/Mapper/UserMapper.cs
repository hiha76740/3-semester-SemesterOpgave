using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Users;
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

    public static TokenResponse AsTokenResponse(this TokenDto dto)
    {
        var output = new TokenResponse(
            dto.AccessToken,
            dto.RefreshToken
            );

        return output;
    }

    public static RefreshTokenCommand AsTokenCommand(this RefreshTokenRequest request)
    {
        var output = new RefreshTokenCommand(
            request.UserId,
            request.RefreshToken
            );

        return output;
    }
}
