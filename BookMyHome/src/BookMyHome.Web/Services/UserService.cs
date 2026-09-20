using BookMyHome.Web.Models;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services
{
    public class UserService(HttpClient httpClient) : IUserService
    {
        private readonly string baseUrl = "http://localhost:9000/";

        Task IUserService.Login()
        {
            throw new NotImplementedException();
        }

        async Task<int> IUserService.Register(UserModel model)
        {
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}api/v1/Auth/register", model);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }
    }
}
