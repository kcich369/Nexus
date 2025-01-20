using Nexus.Shared.Domain.Persistence;

namespace Nexus.Shared.Persistence.Transactions;

public class TransactionManager : ITransactionManager
{
    public Task<bool> BeginTransaction(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CommitTransaction(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RollbackTransaction(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}