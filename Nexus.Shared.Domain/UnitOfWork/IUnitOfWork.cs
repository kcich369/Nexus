namespace Nexus.Shared.Domain.UnitOfWork;

public interface IUnitOfWork
{
    Task<int> SaveChanges(CancellationToken cancellationToken = default);
}