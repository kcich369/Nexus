using Nexus.Shared.Domain.UnitOfWork;

namespace Nexus.Shared.Persistence.Context;

public class UnitOfWork: IUnitOfWork
{
    public Task<int> SaveChanges(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}