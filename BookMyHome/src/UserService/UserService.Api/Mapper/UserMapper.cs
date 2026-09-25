using BookMyHome.ContractsLib.Responses.Users;
using UserService.FacadeLib.Queries.DTOs;

namespace UserService.Api.Mapper
{
    public static class UserMapper
    {
        public static AccessRoleReponse AsAccessRoleResponse(this AccessRoleDto dto)
        {
            var output = new AccessRoleReponse(dto.Role);

            return output;
        }

        public static UserResponse AsUserResponse(this UserDto dto)
        {
            var output = new UserResponse(
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

    }
}
