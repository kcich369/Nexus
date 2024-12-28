using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Dispatcher;

internal class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public async ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command,
        CancellationToken token)
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult
    {
        var validator = serviceProvider.GetRequiredService<ICommandValidator<TCommand, TCommandResult>>();
        if (validator is not null)
        {
            var validationResult = await validator.Validate(command, token);
            if (validationResult.IsError)
                return validationResult;
        }

        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
        return await handler.Handle(command, token);
    }
}