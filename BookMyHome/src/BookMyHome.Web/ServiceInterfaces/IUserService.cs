using BookMyHome.ContractsLib.Responses.Users;

namespace BookMyHome.Web.ServiceInterfaces;

/// <summary>
/// 
/// </summary>
public interface IUserService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<AccessRoleReponse>> GetAllAccessRoles();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserResponse> GetUserById(Guid id);
}
