using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class GuestService(HttpClient httpClient) : IGuestService
{
    //TODO: change when we learn about calling other services
    private readonly string baseUrl = "http://BookMyHome-UserService:8080/";

    async Task<bool> IGuestService.GuestExistAsync(GuestId id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Users/exists?userId={id.Value}");

        var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var exists = await response.Content.ReadFromJsonAsync<bool>();

        return exists;
    }
}
