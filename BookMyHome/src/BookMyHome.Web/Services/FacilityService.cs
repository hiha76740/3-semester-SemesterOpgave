using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services;

/// <summary>
/// 
/// </summary>
/// <param name="httpClient"></param>
public class FacilityService(HttpClient httpClient) : IFacilityService
{
    private readonly string _baseUrl = "/facilities-api";


    async Task<IReadOnlyList<FacilityResponse>> IFacilityService.GetAllFacilitiesAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var facilities = await response.Content.ReadFromJsonAsync<IReadOnlyList<FacilityResponse>>()
            ?? throw new InvalidOperationException("Could not deserialize listings");

        return facilities;
    }

    async Task IFacilityService.AddFacilityAsync(Guid facilityId, Guid accomodationId)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"{_baseUrl}/{accomodationId}")
        {
            Content = JsonContent.Create(new AddFacilityRequest(facilityId))
        };
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }

    async Task IFacilityService.RemoveFacilityAsync(Guid facilityId, Guid accomodationId)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"{_baseUrl}/{accomodationId}")
        {
            Content = JsonContent.Create(new RemoveFacilityRequest(facilityId))
        };
        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }
}
