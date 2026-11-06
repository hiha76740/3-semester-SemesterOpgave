using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Accomodations;
using Dapr.Client;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

/// <summary>
/// 
/// </summary>
/// <param name="daprClient"></param>
public class ListingService(DaprClient daprClient) : IListingService
{
    private readonly HttpClient _client = daprClient.CreateInvokableHttpClient(appId: "accomodationservice");

    private readonly string _baseUrl = "api/v1/Listings";

    async Task<ListingEmailItemResponse> IListingService.GetListingEmailItemAsync(ListingId id)
    {
        var response = await _client.GetAsync($"{_baseUrl}/emailitem?listingId={id.Value}");

        response.EnsureSuccessStatusCode();

        var item = await response.Content.ReadFromJsonAsync<ListingEmailItemResponse>()
            ?? throw new InvalidOperationException("Could not deserialize guest info for email");

        return item;
    }
}
