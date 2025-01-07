using Nexus.Shared.Domain.ValueObjects;

namespace Nexus.Shared.Domain.Domain;

public abstract class Entity<T> :BaseEntity<T> where T : EntityKey
{ 
    public UpdatedAt? UpdatedAt { get; private set; }
    public UpdatedBy? UpdatedBy { get; private set; }

    protected Entity()
    {
    }

    public Entity<T> UpdateData(UpdatedAt updatedAt, UpdatedBy updatedBy)
    {
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
        return this;
    }
}