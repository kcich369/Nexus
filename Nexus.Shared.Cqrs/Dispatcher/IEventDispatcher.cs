using Nexus.Shared.Domain.Events;

namespace Nexus.Shared.Cqrs.Dispatcher;

public interface IEventDispatcher
{
    ValueTask Dispatch<TEvent>(TEvent @event, CancellationToken token)
        where TEvent : IDomainEvent;
}