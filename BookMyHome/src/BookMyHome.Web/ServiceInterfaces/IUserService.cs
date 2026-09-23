using BookMyHome.ContractsLib.Responses.Users;

namespace BookMyHome.Web.ServiceInterfaces
{
    public interface IUserService
    {
        Task<IReadOnlyList<AccessRoleReponse>> GetAllAccessRoles();
    }
}
