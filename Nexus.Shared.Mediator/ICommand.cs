using MediatR;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator;

public interface ICommand : IRequest
{
}

public interface ICommand<out T> : IRequest<IResult<T>>
{
}