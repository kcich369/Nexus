using Nexus.Shared.Domain.Events;

namespace Nexus.Shared.Cqrs.Dispatcher;

public interface IEventDispatcher
{
    Task<bool> Dispatch<TEvent>(TEvent @event, CancellationToken token)
        where TEvent : IDomainEvent;
}