namespace Nexus.Shared.Cqrs.Interfaces;

public interface IEventHandler<in TEvent> where TEvent : IIntegrationEvent
{
    ValueTask Handle(TEvent @event, CancellationToken token);
}