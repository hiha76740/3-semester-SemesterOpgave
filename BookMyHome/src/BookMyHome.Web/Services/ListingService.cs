using BookMyHome.ContractsLib.Requests.Accomodations;
using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Globalization;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services;

/// <summary>
/// 
/// </summary>
/// <param name="httpClient"></param>
public class ListingService(HttpClient httpClient) : IListingService
{
    private readonly string _baseUrl = "/listings-api";


    async Task<int> IListingService.Create(CreateListingRequest createRequest, IBrowserFile? imageFile)
    {
        using var content = new MultipartFormDataContent();


        var requestContent = JsonContent.Create(createRequest);
        content.Add(requestContent, "data");


        if (imageFile != null)
        {
            const long MaxFileSize = 5 * 1024 * 1024;
            var fileContent = new StreamContent(imageFile.OpenReadStream(MaxFileSize));
            content.Add(fileContent, "file", imageFile.Name);
        }

        var request = new HttpRequestMessage(HttpMethod.Post, $"/{_baseUrl}")
        {
            Content = content
        };

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        return (int)response.StatusCode;
    }

    async Task<int> IListingService.UpdateListing(Guid accomodationId, Guid listingId, UpdateListingRequest updateRequest, IBrowserFile? imageFile)
    {
        using var content = new MultipartFormDataContent();

        var requestContent = JsonContent.Create(updateRequest);
        content.Add(requestContent, "data");

        if (imageFile != null)
        {
            const long MaxFileSize = 5 * 1024 * 1024;
            var fileContent = new StreamContent(imageFile.OpenReadStream(MaxFileSize));
            content.Add(fileContent, "file", imageFile.Name);
        }

        var request = new HttpRequestMessage(HttpMethod.Put, $"{_baseUrl}/{accomodationId}/listings/{listingId}")
        {
            Content = content
        };

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        return (int)response.StatusCode;
    }

    async Task<Guid> IListingService.GetAccomodationIdByListingId(Guid listingId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/{listingId}/accomodationId");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var guid = await response.Content.ReadFromJsonAsync<Guid?>()
            ?? throw new InvalidOperationException("Could not deserialize accomodation id");

        return guid;
    }

    async Task<IReadOnlyList<ListingResponse>> IListingService.GetAccomodationListings(Guid accomodationId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/{accomodationId}/listings");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var list = await response.Content.ReadFromJsonAsync<IReadOnlyList<ListingResponse>>()
            ?? throw new InvalidOperationException("Could not deserialize listings");

        return list;
    }

    async Task<IReadOnlyList<ListingResponse>> IListingService.GetAllAvailiableListingsByPeriod(DateOnly start, DateOnly end)
    {
        var from = start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        var to = end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/period?start={from}&end={to}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var listings = await response.Content.ReadFromJsonAsync<IReadOnlyList<ListingResponse>>()
            ?? throw new InvalidOperationException("Could not deserialize listings");

        return listings;
    }

    async Task<IReadOnlyList<ListingResponse>> IListingService.GetAllListingsAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var listings = await response.Content.ReadFromJsonAsync<IReadOnlyList<ListingResponse>>()
            ?? throw new InvalidOperationException("Could not deserialize listings");

        return listings;
    }

    async Task<ListingResponse> IListingService.GetListingDetailsAsync(Guid accomodationId, Guid listingId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/details/{accomodationId}/listings/{listingId}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var listing = await response.Content.ReadFromJsonAsync<ListingResponse>()
            ?? throw new InvalidOperationException("Could not deserialize listings");

        return listing;

    }
}
