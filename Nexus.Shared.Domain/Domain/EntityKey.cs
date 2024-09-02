namespace Nexus.Shared.Domain.Domain;

public abstract record EntityKey;

public abstract record EntityKey<T>(T Id) : EntityKey
{
    public T Id { get; private set; } = Id;
}