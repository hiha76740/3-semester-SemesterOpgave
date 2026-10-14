using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using Dapr.Client;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class ListingService(DaprClient daprClient) : IListingService
{
    private readonly HttpClient client = daprClient.CreateInvokableHttpClient(appId: "accomodationservice");


    async Task<bool> IListingService.ListingExistAsync(ListingId id)
    {
        var response = await client.GetAsync($"exists?id={id.Value}");

        response.EnsureSuccessStatusCode();

        var exists = await response.Content.ReadFromJsonAsync<bool>();

        return exists;
    }
}
