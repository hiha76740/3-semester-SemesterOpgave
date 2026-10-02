using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services
{
    public class FacilityService(HttpClient httpClient) : IFacilityService
    {
        private readonly string baseUrl = "https://localhost:9012/";

        async Task<IReadOnlyList<FacilityResponse>> IFacilityService.GetAllFacilitiesAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Facilities");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var facilities = await response.Content.ReadFromJsonAsync<IReadOnlyList<FacilityResponse>>();

            if (facilities == null)
                throw new InvalidOperationException("Could not deserialize listings");

            return facilities;
        }
    }
}
