using Nexus.Shared.Domain.ValueObjects;

namespace Nexus.Shared.Domain.Domain;

public abstract class Entity<T> where T : EntityKey
{
    public CreatedAt CreatedAt { get; private set; }
    public CreatedBy CreatedBy { get; private set; }
    public UpdatedAt? UpdatedAt { get; private set; }
    public UpdatedBy? UpdatedBy { get; private set; }

    protected Entity()
    {
    }

    public Entity<T> CreationData(CreatedAt createdAt, CreatedBy createdBy)
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
        return this;
    }

    public Entity<T> UpdateData(UpdatedAt updatedAt, UpdatedBy updatedBy)
    {
        UpdatedAt = updatedAt;
        UpdatedBy = updatedBy;
        return this;
    }
}