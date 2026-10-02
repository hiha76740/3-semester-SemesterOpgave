using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services
{
    public class AccomodationService(HttpClient httpClient) : IAccomodationService
    {
        private readonly string baseUrl = "https://localhost:9012/";

        async Task<int> IAccomodationService.Create(CreateAccomodationRequest createRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}api/v1/Accomodations")
            {
                Content = JsonContent.Create(createRequest)
            };

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            return (int)response.StatusCode;
        }

        async Task<IReadOnlyList<AccomodationResponse>> IAccomodationService.GetCurrentUserAccomodationsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Accomodations");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var accomodation = await response.Content.ReadFromJsonAsync<IReadOnlyList<AccomodationResponse>>();

            if (accomodation == null)
                throw new InvalidOperationException("Could not deserialize accomodation");

            return accomodation;
        }
    }
}
