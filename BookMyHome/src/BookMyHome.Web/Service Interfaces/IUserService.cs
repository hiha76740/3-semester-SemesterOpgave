using BookMyHome.ContractsLib.Responses.Users;

namespace BookMyHome.Web.Services
{
    public interface IUserService
    {
        Task<IReadOnlyList<AccessRoleReponse>> GetAllAccessRoles();
    }
}
