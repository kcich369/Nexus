using MediatR;

namespace Nexus.Shared.Mediator;

public interface ICommand<out T> where T : IRequest<T>
{
}