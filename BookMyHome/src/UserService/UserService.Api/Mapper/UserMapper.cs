using BookMyHome.ContractsLib.Responses.Users;
using UserService.FacadeLib.Queries.DTOs;

namespace UserService.Api.Mapper;

/// <summary>
/// 
/// </summary>
public static class UserMapper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static AccessRoleReponse AsAccessRoleResponse(this AccessRoleDto dto)
    {
        var output = new AccessRoleReponse(dto.Role);

        return output;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static UserResponse AsUserResponse(this UserDto dto)
    {
        var output = new UserResponse(
            dto.Id,
            dto.Firstname,
            dto.Lastname,
            dto.Birthdate,
            dto.Street,
            dto.PostalCode,
            dto.City,
            dto.PhoneNumber,
            dto.Email,
            dto.Username
            );

        return output;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static UserEmailItemResponse AsUserEmailItemResponse(this UserEmailItemDto dto)
    {
        var output = new UserEmailItemResponse
            (dto.Firstname,
            dto.Lastname,
            dto.Email);

        return output;
    }

}
