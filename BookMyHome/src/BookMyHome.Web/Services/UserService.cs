using BookMyHome.ContractsLib.Responses.Users;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
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

        async Task<UserResponse> IUserService.GetUserById(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Users/{id}");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var user = await response.Content.ReadFromJsonAsync<UserResponse>();

            if (user == null)
                throw new InvalidOperationException("Could not deserialize authenticated user");

            return user;
        }
    }
}
