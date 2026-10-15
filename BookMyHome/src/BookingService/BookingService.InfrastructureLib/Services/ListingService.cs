using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using Dapr.Client;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class ListingService(DaprClient daprClient) : IListingService
{
    private readonly HttpClient client = daprClient.CreateInvokableHttpClient(appId: "accomodationservice");

    private readonly string baseUrl = "api/v1/Listings";


    async Task<bool> IListingService.ListingExistAsync(ListingId id)
    {
        var response = await client.GetAsync($"{baseUrl}/exists?id={id.Value}");

        response.EnsureSuccessStatusCode();

        var exists = await response.Content.ReadFromJsonAsync<bool>();

        return exists;
    }
}
