using Nexus.Shared.Domain.ValueObjects;

namespace Nexus.Shared.Domain.Domain;

public class BaseEntity<T> where T : EntityKey
{
    public T Id { get; private set; }
    public CreatedAt CreatedAt { get; private set; }
    public CreatedBy CreatedBy { get; private set; }

    protected BaseEntity()
    {
    }

    public BaseEntity<T> CreationData(CreatedAt createdAt, CreatedBy createdBy)
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        return this;
    }
}