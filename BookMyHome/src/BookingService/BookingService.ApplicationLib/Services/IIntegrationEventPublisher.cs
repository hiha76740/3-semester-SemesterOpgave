namespace BookingService.ApplicationLib.Services;

public interface IIntegrationEventPublisher
{
    Task PublishAsync<T>(string topic, T integrationEvent);
}
