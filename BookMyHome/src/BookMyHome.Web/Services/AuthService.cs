using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Authentication;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;


namespace BookMyHome.Web.Services;

/// <summary>
/// 
/// </summary>
/// <param name="httpClient"></param>
public class AuthService(HttpClient httpClient) : IAuthService
{
    private readonly string _baseUrl = "auth-api";


    async Task<AuthUserResponse> IAuthService.GetAuthUserAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/Me");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var authUser = await response.Content.ReadFromJsonAsync<AuthUserResponse>()
            ?? throw new InvalidOperationException("Could not deserialize authenticated user");

        return authUser;
    }

    async Task<int> IAuthService.Login(string username, string password)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/login")
        {
            Content = JsonContent.Create(new LoginRequest(username, password))
        };

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        return (int)response.StatusCode;
    }

    async Task IAuthService.LogOut()
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/logout");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

    }

    async Task<int> IAuthService.Register(RegisterUserRequest request)
    {
        using var response = await httpClient.PostAsJsonAsync($"{_baseUrl}/register", request);

        return (int)response.StatusCode;
    }
}
