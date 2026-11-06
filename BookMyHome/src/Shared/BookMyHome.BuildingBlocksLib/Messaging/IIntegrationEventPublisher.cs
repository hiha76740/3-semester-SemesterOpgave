namespace BookMyHome.BuildingBlocksLib.Messaging;

/// <summary>
/// 
/// </summary>
public interface IIntegrationEventPublisher
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="topic"></param>
    /// <param name="integrationEvent"></param>
    /// <returns></returns>
    Task PublishAsync<T>(string topic, T integrationEvent);
}
