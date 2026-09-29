using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.ValueObjects;
using System.Net.Http.Json;

namespace BookingService.InfrastructureLib.Services;

public class AccomodationService(HttpClient httpClient) : IAccomodationService
{
    private readonly string baseUrl = "http://BookMyHome-AccomodationService:8080";

    async Task<bool> IAccomodationService.AccomodationExistAsync(AccomodationId id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Accomodations/exists?id={id.Value}");

        var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var exists = await response.Content.ReadFromJsonAsync<bool>();

        return exists;
    }
}
