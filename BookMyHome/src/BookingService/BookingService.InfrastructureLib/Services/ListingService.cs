using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Dapr.Client;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class ListingService(DaprClient daprClient) : IListingService
{
    private readonly HttpClient client = daprClient.CreateInvokableHttpClient(appId: "accomodationservice");

    private readonly string baseUrl = "api/v1/Listings";

    async Task<ListingEmailItemResponse> IListingService.GetListingEmailItemAsync(ListingId id)
    {
        var response = await client.GetAsync($"{baseUrl}/emailitem?listingId={id.Value}");

        response.EnsureSuccessStatusCode();

        var item = await response.Content.ReadFromJsonAsync<ListingEmailItemResponse>();

        if (item == null)
            throw new InvalidOperationException("Could not deserialize guest info for email");

        return item;
    }

    
}
