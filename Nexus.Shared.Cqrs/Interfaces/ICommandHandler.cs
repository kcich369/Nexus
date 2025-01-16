using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Cqrs.Interfaces;

public interface ICommandHandler<TCommand, TResult> 
    where TCommand : ICommand<TResult> where TResult : ICommandResult
{
    ValueTask<IResult<TResult>> Handle(TCommand command, IValidationContext<TCommand> validationContext = null, CancellationToken token = default);
}

