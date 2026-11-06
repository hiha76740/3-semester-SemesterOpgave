using BookMyHome.ContractsLib.Responses.Users;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services;

/// <summary>
/// 
/// </summary>
/// <param name="httpClient"></param>
public class UserService(HttpClient httpClient) : IUserService
{
    private readonly string _baseUrl = "/users-api";


    async Task<IReadOnlyList<AccessRoleReponse>> IUserService.GetAllAccessRoles()
    {
        var response = await httpClient.GetFromJsonAsync<IReadOnlyList<AccessRoleReponse>>($"{_baseUrl}/Roles");

        if (response == null)
            return [];

        return response;
    }

    async Task<UserResponse> IUserService.GetUserById(Guid id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/{id}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var user = await response.Content.ReadFromJsonAsync<UserResponse>()
            ?? throw new InvalidOperationException("Could not deserialize authenticated user");

        return user;
    }
}
