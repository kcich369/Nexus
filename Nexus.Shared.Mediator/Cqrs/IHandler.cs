using MediatR;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs;

public interface ICommandHandler<in TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : ICommand<TResult>, IRequest<TResult> where TResult : ICommandResult
{
    ValueTask<IResult<TResult>> Handle(TRequest command);
}

public interface IQueryHandler<in TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IQuery<TResult>, IRequest<TResult> where TResult : IQueryResult
{
    ValueTask<IResult<TResult>> Handle(TRequest command);
}