using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.Web.ServiceInterfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Net.Http.Json;

namespace BookMyHome.Web.Services;

public class BookingService(HttpClient httpClient) : IBookingService
{
    private readonly string baseUrl = "https://localhost:9011/";

    async Task IBookingService.MakeBooking(CreateBookingRequest CreateRequest)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseUrl}api/v1/Bookings")
        {
            Content = JsonContent.Create(CreateRequest)
        };

        request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);

        using var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();
    }
}
