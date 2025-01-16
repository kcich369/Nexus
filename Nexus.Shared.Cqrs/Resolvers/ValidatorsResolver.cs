using Microsoft.Extensions.DependencyInjection;
using Nexus.Shared.Cqrs.Interfaces;

namespace Nexus.Shared.Cqrs.Resolvers;

internal class ValidatorsResolver(IServiceProvider serviceProvider)
{
    public ICommandValidator<TCommand, TCommandResult> GetValidator<TCommand, TCommandResult>()
        where TCommand : ICommand<TCommandResult> where TCommandResult : ICommandResult
        => serviceProvider.GetService<ICommandValidator<TCommand, TCommandResult>>();
}