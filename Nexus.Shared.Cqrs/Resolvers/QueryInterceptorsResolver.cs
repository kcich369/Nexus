﻿using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Cqrs.Interceptors;
using Nexus.Shared.Cqrs.Interfaces;

namespace Nexus.Shared.Cqrs.Resolvers;

internal class QueryInterceptorsResolver(IServiceProvider serviceProvider)
{
    public IReadOnlyCollection<IInboundQueryInterceptor<TQuery>> InboundInterceptors<TQuery>()
        where TQuery : IQuery =>
        serviceProvider.GetServices<IInboundQueryInterceptor<TQuery>>()
            .OrderBy(x => x.Order)
            .ToList()
            .AsReadOnly();

    public IReadOnlyCollection<IOutboundQueryInterceptor<TResult>> OutboundInterceptors<TResult>()
        where TResult : IQueryResult =>
        serviceProvider.GetServices<IOutboundQueryInterceptor<TResult>>()
            .OrderBy(x => x.Order)
            .ToList()
            .AsReadOnly();
}