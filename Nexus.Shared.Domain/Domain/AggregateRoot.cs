using Nexus.Shared.Domain.Events;

namespace Nexus.Shared.Domain.Domain;

public abstract class AggregateRoot<T> : Entity<T> where T : EntityKey
{
    private readonly List<IDomainEvent> _events = [];

    protected void RaiseEvent(IDomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }

    protected IEnumerable<IDomainEvent> GetEvents() => _events;
    
    protected void ClearEvents() => _events.Clear();
}