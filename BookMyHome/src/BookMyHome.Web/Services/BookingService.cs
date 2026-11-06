using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services;

/// <summary>
/// 
/// </summary>
/// <param name="httpClient"></param>
public class BookingService(HttpClient httpClient) : IBookingService
{
    private readonly string _baseUrl = "/bookings-api";


    async Task IBookingService.CancelBookingAsync(Guid bookingId)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"{_baseUrl}/{bookingId}/cancel");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }

    async Task<IReadOnlyList<BookingSummaryResponse>> IBookingService.GetAccomodationBookingsAsync(Guid accomdationId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/accomodation/bookings?accomdationId={accomdationId}");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var bookings = await response.Content.ReadFromJsonAsync<IReadOnlyList<BookingSummaryResponse>>()
            ?? throw new InvalidOperationException("Could not deserialize bookings");

        return bookings;

    }

    async Task<IReadOnlyList<BookingSummaryResponse>> IBookingService.GetUserBookingsAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_baseUrl}/user/bookings");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var bookings = await response.Content.ReadFromJsonAsync<IReadOnlyList<BookingSummaryResponse>>()
            ?? throw new InvalidOperationException("Could not deserialize bookings");

        return bookings;
    }

    async Task<int> IBookingService.MakeBookingAsync(CreateBookingRequest createRequest)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/")
        {
            Content = JsonContent.Create(createRequest)
        };

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return (int)response.StatusCode;
    }
}
