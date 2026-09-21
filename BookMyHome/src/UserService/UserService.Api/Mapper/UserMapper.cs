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
    }
}
