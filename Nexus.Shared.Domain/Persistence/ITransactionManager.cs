namespace Nexus.Shared.Domain.Persistence;

public interface ITransactionManager
{
    Task<bool> BeginTransaction(CancellationToken cancellationToken = default);
    Task<bool> CommitTransaction(CancellationToken cancellationToken = default);
    Task<bool> RollbackTransaction(CancellationToken cancellationToken = default);
}