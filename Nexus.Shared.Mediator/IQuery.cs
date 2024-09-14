using MediatR;
using Nexus.Shared.Domain.Result;

namespace Nexus.Shared.Mediator;

public interface IQuery<out T> : IRequest<IResult<T>>
{
}