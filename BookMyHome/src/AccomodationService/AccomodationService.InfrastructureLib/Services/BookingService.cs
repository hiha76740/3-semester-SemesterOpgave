using AccomodationService.FacadeLib.Queries.Interfaces;
using System.Net.Http.Json;

namespace AccomodationService.InfrastructureLib.Services;

public class BookingService(HttpClient httpClient) : IBookingService
{
    private readonly string baseUrl = "https://localhost:9011/";

    async Task<bool> IBookingService.IsAvailableAsync(Guid accomodationId, DateOnly start, DateOnly end)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Bookings/availability?id={accomodationId}&startDate={start}&endDate={end}");

        var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var available = await response.Content.ReadFromJsonAsync<bool>();

        return available;
    }
}
