using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Dispatcher;

internal class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public async ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command)
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult
    {
        var validator = serviceProvider.GetRequiredService<ICommandValidator<TCommand, TCommandResult>>();
        var validationResult = await validator.Validate(command);
        if (validationResult.IsError)
            return validationResult;
        
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
        return await handler.Handle(command);
    }
}