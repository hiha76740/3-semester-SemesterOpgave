using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.Web.Service_Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services
{
    public class ListingService(HttpClient httpClient) : IListingService
    {
        private readonly string baseUrl = "https://localhost:9012/";

        async Task<IReadOnlyList<ListingResponse>> IListingService.GetAllListings()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Listings");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var listings = await response.Content.ReadFromJsonAsync<IReadOnlyList<ListingResponse>>();

            if (listings == null)
                throw new InvalidOperationException("Could not deserialize listings");

            return listings;
        }
    }
}
