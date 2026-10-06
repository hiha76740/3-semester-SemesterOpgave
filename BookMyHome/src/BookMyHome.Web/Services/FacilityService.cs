using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services
{
    public class FacilityService(HttpClient httpClient) : IFacilityService
    {
        //private readonly string baseUrl = "https://localhost:9012/";
        private readonly string baseUrl = "https://localhost:8010/facilities-api/";


        async Task<IReadOnlyList<FacilityResponse>> IFacilityService.GetAllFacilitiesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var facilities = await response.Content.ReadFromJsonAsync<IReadOnlyList<FacilityResponse>>();

            if (facilities == null)
                throw new InvalidOperationException("Could not deserialize listings");

            return facilities;
        }

        async Task IFacilityService.AddFacilityAsync(Guid facilityId, Guid accomodationId)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}{accomodationId}")
            {
                Content = JsonContent.Create(new AddFacilityRequest(facilityId))
            };
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }

        async Task IFacilityService.RemoveFacilityAsync(Guid facilityId, Guid accomodationId)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{baseUrl}{accomodationId}")
            {
                Content = JsonContent.Create(new RemoveFacilityRequest(facilityId))
            };
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();
        }
    }
}
