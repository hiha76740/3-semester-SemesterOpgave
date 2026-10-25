namespace BookMyHome.BuildingBlocksLib.Messaging;

public interface IIntegrationEventPublisher
{
    Task PublishAsync<T>(string topic, T integrationEvent);
}
