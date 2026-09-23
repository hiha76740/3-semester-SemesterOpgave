using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services
{
    public class ListingService(HttpClient httpClient) : IListingService
    {
        private readonly string baseUrl = "https://localhost:9012/";

        async Task<Guid> IListingService.GetAccomodationIdByListingId(Guid listingId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Listings/{listingId}/accomodationId");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var guid = await response.Content.ReadFromJsonAsync<Guid?>();

            if (guid == null)
                throw new InvalidOperationException("Could not deserialize accomodation id");

            return guid.Value;
        }

        async Task<IReadOnlyList<ListingResponse>> IListingService.GetAllListingsAsync()
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

        async Task<ListingResponse> IListingService.GetListingAsync(Guid accomodationId,Guid listingId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Listings/{accomodationId}/listings/{listingId}");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var listing = await response.Content.ReadFromJsonAsync<ListingResponse>();

            if (listing == null)
                throw new InvalidOperationException("Could not deserialize listings");

            return listing;

        }
    }
}
