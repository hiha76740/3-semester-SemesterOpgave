using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Globalization;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services
{
    public class ListingService(HttpClient httpClient) : IListingService
    {
        private readonly string baseUrl = "https://localhost:9012/";

        async Task<int> IListingService.Create(CreateListingRequest createRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}api/v1/Listings")
            {
                Content = JsonContent.Create(createRequest)
            };
            
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            return (int)response.StatusCode;
        }

        async Task<Guid> IListingService.GetAccomodationIdByListingId(Guid listingId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Listings/{listingId}/accomodationId");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var guid = await response.Content.ReadFromJsonAsync<Guid?>();

            if (guid == null)
                throw new InvalidOperationException("Could not deserialize accomodation id");

            return guid.Value;
        }

        async Task<IReadOnlyList<ListingResponse>> IListingService.GetAccomodationListings(Guid accomodationId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Listings/{accomodationId}/listings");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var list = await response.Content.ReadFromJsonAsync<IReadOnlyList<ListingResponse>>();

            if (list == null)
                throw new InvalidOperationException("Could not deserialize listings");

            return list;
        }

        async Task<IReadOnlyList<AccomodationTypeResponse>> IListingService.GetAllAccomodationTypes()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Accomodations/types");

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var list = await response.Content.ReadFromJsonAsync<IReadOnlyList<AccomodationTypeResponse>>();

            if (list == null)
                throw new InvalidOperationException("Could not deserialize accomodation types");

            return list;
        }

        async Task<IReadOnlyList<ListingResponse>> IListingService.GetAllAvailiableListingsByPeriod(DateOnly start, DateOnly end)
        {
            var from = start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            var to = end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Listings/period?start={from}&end={to}");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var listings = await response.Content.ReadFromJsonAsync<IReadOnlyList<ListingResponse>>();

            if (listings == null)
                throw new InvalidOperationException("Could not deserialize listings");

            return listings;
        }

        async Task<IReadOnlyList<ListingResponse>> IListingService.GetAllListingsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Listings");

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

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

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var listing = await response.Content.ReadFromJsonAsync<ListingResponse>();

            if (listing == null)
                throw new InvalidOperationException("Could not deserialize listings");

            return listing;

        }

        async Task<int> IListingService.UpdateListing(Guid accomodationId, Guid listingId, UpdateListingRequest updateRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}api/v1/Listings/{accomodationId}/listings/{listingId}")
            {
                Content = JsonContent.Create(updateRequest)
            };

            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

            using var response = await httpClient.SendAsync(request);

            return (int)response.StatusCode;
        }
    }
}
