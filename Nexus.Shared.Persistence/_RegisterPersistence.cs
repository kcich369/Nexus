using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Domain.Persistence;
using Nexus.Shared.Domain.UnitOfWork;
using Nexus.Shared.Persistence.Context;
using Nexus.Shared.Persistence.Transactions;

namespace Nexus.Shared.Persistence;

public static class RegisterPersistence
{
    public static IServiceCollection RegisterCqrs(this IServiceCollection services)
    {
        services.AddScoped<ITransactionManager, TransactionManager>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}