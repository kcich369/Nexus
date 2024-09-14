using MediatR;

namespace Nexus.Shared.Mediator;

public interface IValidator<in TRequest, TResult> where TRequest : ICommand<TResult>, IRequest<TResult>
{
    ValueTask<IRequest<TResult>> Validate(TRequest request, CancellationToken ct);
}