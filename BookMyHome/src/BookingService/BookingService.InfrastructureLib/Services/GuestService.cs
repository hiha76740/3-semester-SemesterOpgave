using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Users;
using Dapr.Client;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

/// <summary>
/// 
/// </summary>
/// <param name="daprClient"></param>
public class GuestService(DaprClient daprClient) : IGuestService
{
    private readonly HttpClient _client = daprClient.CreateInvokableHttpClient(appId: "userservice");

    private readonly string _baseUrl = "api/v1/Users";

    async Task<UserEmailItemResponse> IGuestService.GetGuestEmailItemAsync(GuestId id)
    {
        var response = await _client.GetAsync($"{_baseUrl}/emailitem?userId={id.Value}");

        response.EnsureSuccessStatusCode();

        var item = await response.Content.ReadFromJsonAsync<UserEmailItemResponse>()
            ?? throw new InvalidOperationException("Could not deserialize guest info for email");

        return item;
    }
}
