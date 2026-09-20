using BookMyHome.ContractsLib.Requests.Users;
using System.Net.Http.Json;


namespace BookMyHome.Web.Services
{
    public class UserService(HttpClient httpClient) : IUserService
    {
        private readonly string baseUrl = "http://localhost:9000/";

        async Task IUserService.Login(string username, string password)
        {
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}api/v1/Auth/login", new LoginRequest(username, password));
            
        }

        async Task<int> IUserService.Register(RegisterUserRequest request)
        {
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}api/v1/Auth/register", request);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }
    }
}
