using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator.Cqrs.Resolvers;

internal class ValidatorsResolver(IServiceProvider serviceProvider)
{
    public ICommandValidator<TCommand, TCommandResult> GetValidator<TCommand, TCommandResult>()
        where TCommand : ICommand<IResult<TCommandResult>> where TCommandResult : ICommandResult
        => serviceProvider.GetService<ICommandValidator<TCommand, TCommandResult>>();
}