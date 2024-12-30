﻿using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Interceptors;

public interface IOutboundQueryInterceptor<TResult> where TResult : IQueryResult
{
    byte Order { get; }
    ValueTask<IResult<TResult>> Handle(IResult<TResult> result, CancellationToken token);
}