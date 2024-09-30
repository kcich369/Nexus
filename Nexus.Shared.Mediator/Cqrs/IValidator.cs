using MediatR;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs;

public interface ICommandValidator<in TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : ICommand<TResult>, IRequest<TResult> where TResult : ICommandResult, IRequest<TResult>
{
    ValueTask<IResult<TResult>> Validate(TRequest command);
}