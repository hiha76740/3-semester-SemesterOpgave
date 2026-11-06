using AccomodationService.FacadeLib.Queries.Interfaces;
using Dapr.Client;
using System.Globalization;
using System.Net.Http.Json;

namespace AccomodationService.InfrastructureLib.Services;

/// <summary>
/// 
/// </summary>
/// <param name="daprClient"></param>
public class BookingService(DaprClient daprClient) : IBookingService
{
    private readonly HttpClient _client = daprClient.CreateInvokableHttpClient(appId: "bookingservice");
    private readonly string _baseUrl = "api/v1/Bookings";

    async Task<bool> IBookingService.IsAvailableAsync(Guid accomodationId, DateOnly start, DateOnly end)
    {
        var from = start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        var to = end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        using var response = await _client.GetAsync($"{_baseUrl}/availability?id={accomodationId}&startDate={from}&endDate={to}");

        response.EnsureSuccessStatusCode();

        var available = await response.Content.ReadFromJsonAsync<bool>();

        return available;
    }
}
