using BookMyHome.ContractsLib.Responses.Users;

namespace BookMyHome.Web.Services
{
    public interface IUserService
    {
        public Task<IReadOnlyList<AccessRoleReponse>> GetAllAccessRoles();
    }
}
