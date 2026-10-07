using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class GuestService(HttpClient httpClient) : IGuestService
{
    private readonly string baseUrl = "http://bookmyhome-proxy:8080/users-api/";

    async Task<bool> IGuestService.GuestExistAsync(GuestId id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}exists?userId={id.Value}");

        var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var exists = await response.Content.ReadFromJsonAsync<bool>();

        return exists;
    }
}
