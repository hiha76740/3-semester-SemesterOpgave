using BookMyHome.ContractsLib.Requests.Users;
using BookMyHome.ContractsLib.Responses.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;


namespace BookMyHome.Web.Services
{
    public class AuthService(HttpClient httpClient) : IAuthService
    {
        private readonly string baseUrl = "https://localhost:9010/";

        async Task<AuthUserResponse> IAuthService.GetAuthUserAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Auth/Me");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var authUser = await response.Content.ReadFromJsonAsync<AuthUserResponse>();

            if (authUser == null)
                throw new InvalidOperationException("Could not deserialize authenticated user");

            return authUser;
        }

        async Task<int> IAuthService.Login(string username, string password)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}api/v1/Auth/login");

            request.Content = JsonContent.Create(new LoginRequest(username, password));

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(request);

            return (int)response.StatusCode;
        }

        async Task<int> IAuthService.Register(RegisterUserRequest userRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}api/v1/Auth/register");

            request.Content = JsonContent.Create(userRequest);

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(request);
            
            return (int)response.StatusCode;
        }
    }
}
