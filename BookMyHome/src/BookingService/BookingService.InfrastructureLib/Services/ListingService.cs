using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class ListingService(HttpClient httpClient) : IListingService
{
    private readonly string baseUrl = "http://bookmyhome-proxy:8080/listings-api/";

    async Task<bool> IListingService.ListingExistAsync(ListingId id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}exists?id={id.Value}");

        var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var exists = await response.Content.ReadFromJsonAsync<bool>();

        return exists;
    }
}
