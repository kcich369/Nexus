using MediatR;

namespace Nexus.Shared.Mediator.Cqrs;

public interface ICommand
{
}

public interface ICommand<out T> : ICommand, IRequest<T> where T : ICommandResult
{
}