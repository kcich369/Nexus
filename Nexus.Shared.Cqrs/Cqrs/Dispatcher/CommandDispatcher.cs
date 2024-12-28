using Nexus.Shared.Domain.Result;
using Nexus.Shared.Mediator.Cqrs.Resolvers;

namespace Nexus.Shared.Mediator.Cqrs.Dispatcher;

internal class CommandDispatcher(
    HandlersResolver handlersResolver,
    CommandInterceptorsResolver commandInterceptorsResolver,
    ValidatorsResolver validatorsResolver) : ICommandDispatcher
{
    public async ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command,
        CancellationToken token)
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult
    {
        foreach (var inboundInterceptor in commandInterceptorsResolver.InboundInterceptors<TCommand>())
        {
            await inboundInterceptor.Handle(command, token);
        }

        var validator = validatorsResolver.GetValidator<TCommand, TCommandResult>();
        if (validator is not null)
        {
            var validationResult = await validator.Validate(command, token);
            if (validationResult.IsError)
                return validationResult;
        }

        var handler = handlersResolver.GetHandler<TCommand, TCommandResult>();
        var result = await handler.Handle(command, token);

        foreach (var outboundInterceptor in commandInterceptorsResolver.OutboundInterceptors<TCommandResult>())
        {
            await outboundInterceptor.Handle(result, token);
        }

        return result;
    }
}