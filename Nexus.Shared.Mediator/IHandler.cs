using MediatR;

namespace Nexus.Shared.Mediator;

public interface ICommandHandler<in TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : ICommand<TResult>, IRequest<TResult>
{
}

public interface IQueryHandler<in TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IQuery<TResult>, IRequest<TResult>
{
}