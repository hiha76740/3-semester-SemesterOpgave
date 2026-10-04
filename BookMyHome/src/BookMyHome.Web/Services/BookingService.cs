using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services;

public class BookingService(HttpClient httpClient) : IBookingService
{
    private readonly string baseUrl = "https://localhost:9011/";

    async Task IBookingService.CancelBookingAsync(Guid bookingId)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}api/v1/Bookings/{bookingId}/cancel");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }

    Task<IReadOnlyList<BookingSummaryResponse>> IBookingService.GetAccomodationBookingsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    async Task<IReadOnlyList<BookingSummaryResponse>> IBookingService.GetUserBookingsAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Bookings/user/bookings");

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var bookings = await response.Content.ReadFromJsonAsync<IReadOnlyList<BookingSummaryResponse>>();

        if ( bookings == null )
            throw new InvalidOperationException("Could not deserialize bookings");

        return bookings;
    }

    async Task<int> IBookingService.MakeBookingAsync(CreateBookingRequest CreateRequest)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}api/v1/Bookings")
        {
            Content = JsonContent.Create(CreateRequest)
        };

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        return (int)response.StatusCode;
    }
}
