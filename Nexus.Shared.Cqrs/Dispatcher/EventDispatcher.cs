using Nexus.Shared.Domain.Events;

namespace Nexus.Shared.Cqrs.Dispatcher;

public class EventDispatcher:IEventDispatcher
{
    public ValueTask Dispatch<TEvent>(TEvent @event, CancellationToken token) where TEvent : IDomainEvent
    {
        throw new NotImplementedException();
    }
}