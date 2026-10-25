using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Users;
using Dapr.Client;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class GuestService(DaprClient daprClient) : IGuestService
{
    private readonly HttpClient client = daprClient.CreateInvokableHttpClient(appId: "userservice");

    private readonly string baseUrl = "api/v1/Users";

    async Task<UserEmailItemResponse> IGuestService.GetGuestEmailItemAsync(GuestId id)
    {
        var response = await client.GetAsync($"{baseUrl}/emailitem?userId={id.Value}");

        response.EnsureSuccessStatusCode();

        var item = await response.Content.ReadFromJsonAsync<UserEmailItemResponse>();

        if (item == null)
            throw new InvalidOperationException("Could not deserialize guest info for email");

        return item;
    }
}
