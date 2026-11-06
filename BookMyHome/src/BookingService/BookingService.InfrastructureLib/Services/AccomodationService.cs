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
public class AccomodationService(DaprClient daprClient) : IAccomodationService
{
    private readonly HttpClient _client = daprClient.CreateInvokableHttpClient(appId: "accomodationservice");

    private readonly string _baseUrl = "api/v1/Accomodations";

    async Task<bool> IAccomodationService.AccomodationExistAsync(AccomodationId id)
    {
        using var response = await _client.GetAsync($"{_baseUrl}/exists?id={id.Value}");

        response.EnsureSuccessStatusCode();

        var exists = await response.Content.ReadFromJsonAsync<bool>();

        return exists;
    }

    async Task<Guid> IAccomodationService.GetAccmodationHostIdAsync(AccomodationId accomodationId)
    {
        using var response = await _client.GetAsync($"{_baseUrl}/hostid?accomodationId={accomodationId.Value}");

        response.EnsureSuccessStatusCode();

        var id = await response.Content.ReadFromJsonAsync<Guid>();

        return id;
    }

    async Task<AccomodationSummaryResponse> IAccomodationService.GetAccomodationSummaryAsync(Guid accomodationId, Guid listingId)
    {
        using var response = await _client.GetAsync($"{_baseUrl}/summary?accomodationId={accomodationId}&listingId={listingId}");

        response.EnsureSuccessStatusCode();

        var summary = await response.Content.ReadFromJsonAsync<AccomodationSummaryResponse>()
            ?? throw new InvalidOperationException("Could not deserialize summary");

        return summary;
    }
}
