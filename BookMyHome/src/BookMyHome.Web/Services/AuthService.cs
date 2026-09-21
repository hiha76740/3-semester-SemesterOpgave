using BookMyHome.ContractsLib.Requests.Users;
using System.Net.Http.Json;


namespace BookMyHome.Web.Services
{
    public class AuthService(HttpClient httpClient) : IAuthService
    {
        private readonly string baseUrl = "http://localhost:9000/";

        async Task IAuthService.Login(string username, string password)
        {
            await httpClient.PostAsJsonAsync($"{baseUrl}api/v1/Auth/login", new LoginRequest(username, password));
        }

        async Task<int> IAuthService.Register(RegisterUserRequest request)
        {
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}api/v1/Auth/register", request);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }
    }
}
