using AccomodationService.FacadeLib.Queries.Interfaces;
using System.Globalization;
using System.Net.Http.Json;

namespace AccomodationService.InfrastructureLib.Services;

public class BookingService(HttpClient httpClient) : IBookingService
{
    private readonly string baseUrl = "http://BookMyHome-BookingService:8080/";

    async Task<bool> IBookingService.IsAvailableAsync(Guid accomodationId, DateOnly start, DateOnly end)
    {
        var from = start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        var to = end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}api/v1/Bookings/availability?id={accomodationId}&startDate={from}&endDate={to}");

        var response = await httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var available = await response.Content.ReadFromJsonAsync<bool>();

        return available;
    }
}
