using BookMyHome.ContractsLib.Responses.Users;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services
{
    public class UserService(HttpClient httpClient) : IUserService
    {
        private readonly string baseUrl = "https://localhost:9010/";

        async Task<IReadOnlyList<AccessRoleReponse>> IUserService.GetAllAccessRoles()
        {
            var response = await httpClient.GetFromJsonAsync<IReadOnlyList<AccessRoleReponse>>($"{baseUrl}api/v1/Users/Roles");

            if (response == null)
                return new List<AccessRoleReponse>();

            return response;
        }
    }
}
