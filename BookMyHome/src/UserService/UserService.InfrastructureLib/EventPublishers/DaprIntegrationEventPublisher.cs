using BookMyHome.BuildingBlocksLib.Messaging;
using Dapr.Client;

namespace UserService.InfrastructureLib.EventPublishers;

public class DaprIntegrationEventPublisher(DaprClient daprClient) : IIntegrationEventPublisher
{
    Task IIntegrationEventPublisher.PublishAsync<T>(string topic, T integrationEvent)
    {
        return daprClient.PublishEventAsync(
        "pubsub",
        topic,
        integrationEvent
        );
    }
}
