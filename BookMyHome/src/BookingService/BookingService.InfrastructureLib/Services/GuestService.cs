using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using Dapr.Client;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class GuestService(DaprClient daprClient) : IGuestService
{
    private readonly HttpClient client = daprClient.CreateInvokableHttpClient(appId: "userservice");

    private readonly string baseUrl = "api/v1/Users";

    async Task<bool> IGuestService.GuestExistAsync(GuestId id)
    {
        var response = await client.GetAsync($"{baseUrl}/exists?userId={id.Value}");

        response.EnsureSuccessStatusCode();

        var exists = await response.Content.ReadFromJsonAsync<bool>();

        return exists;
    }
}
