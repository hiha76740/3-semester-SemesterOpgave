using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using BookMyHome.ContractsLib.Responses.Accomodations;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class AccomodationService(HttpClient httpClient) : IAccomodationService
{
    private readonly string baseUrl = "http://bookmyhome-proxy:8080/accomodations-api/";


    async Task<bool> IAccomodationService.AccomodationExistAsync(AccomodationId id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}exists?id={id.Value}");

        var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var exists = await response.Content.ReadFromJsonAsync<bool>();

        return exists;
    }

    async Task<Guid> IAccomodationService.GetAccmodationHostIdAsync(AccomodationId accomodationId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}hostid?accomodationId={accomodationId.Value}");

        var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var id = await response.Content.ReadFromJsonAsync<Guid>();

        return id;
    }

    async Task<AccomodationSummaryResponse> IAccomodationService.GetAccomodationSummaryAsync(Guid accomodationId, Guid listingId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}summary?accomodationId={accomodationId}&listingId={listingId}");

        var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var summary = await response.Content.ReadFromJsonAsync<AccomodationSummaryResponse>();

        if (summary == null)
            throw new InvalidOperationException("Could not deserialize summary");

        return summary;
    }
}
