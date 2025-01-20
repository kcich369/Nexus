using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Cqrs.Resolvers;
using Nexus.Shared.Domain.Persistence;
using Nexus.Shared.Domain.Results;
using Nexus.Shared.Domain.Results.Abstractions;
using Nexus.Shared.Domain.UnitOfWork;

namespace Nexus.Shared.Cqrs.Dispatcher;

internal class CommandDispatcher(
    HandlersResolver handlersResolver,
    CommandInterceptorsResolver commandInterceptorsResolver,
    ValidatorsResolver validatorsResolver,
    ITransactionManager transactionManager) : ICommandDispatcher
{
    public async ValueTask<IResult<TCommandResult>> Dispatch<TCommand, TCommandResult>(TCommand command,
        CancellationToken token)
        where TCommand : ICommand<TCommandResult> where TCommandResult : ICommandResult
    {
        try
        {
            await transactionManager.BeginTransaction(token);
            foreach (var inboundInterceptor in commandInterceptorsResolver.InboundInterceptors<TCommand>())
            {
                await inboundInterceptor.Handle(command, token);
            }

            IResult<IValidationContext<TCommand>> validationContext = null;
            var validator = validatorsResolver.GetValidator<TCommand, TCommandResult>();
            if (validator is not null)
            {
                validationContext = await validator.Validate(command, token);
                if (validationContext.IsError)
                    return validationContext.MapToResult<TCommandResult>(default);
            }

            var handler = handlersResolver.GetCommandHandler<TCommand, TCommandResult>();
            var result = await handler.Handle(command, validationContext?.Data, token);

            foreach (var outboundInterceptor in
                     commandInterceptorsResolver.OutboundInterceptors<TCommand, TCommandResult>())
            {
                await outboundInterceptor.Handle(command, result, token);
            }
            
            await transactionManager.CommitTransaction(token);
            return result;
        }
        catch
        {
            await transactionManager.RollbackTransaction(token);
            throw;
        }
    }
}