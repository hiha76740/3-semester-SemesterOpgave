using AccomodationService.FacadeLib.Queries.Interfaces;
using Dapr.Client;
using System.Globalization;
using System.Net.Http.Json;

namespace AccomodationService.InfrastructureLib.Services;

public class BookingService(DaprClient daprClient) : IBookingService
{
    private readonly HttpClient client = daprClient.CreateInvokableHttpClient(appId: "bookingservice");

    async Task<bool> IBookingService.IsAvailableAsync(Guid accomodationId, DateOnly start, DateOnly end)
    {
        var from = start.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        var to = end.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

        using var response = await client.GetAsync($"availability?id={accomodationId}&startDate={from}&endDate={to}");

        response.EnsureSuccessStatusCode();

        var available = await response.Content.ReadFromJsonAsync<bool>();

        return available;
    }
}
