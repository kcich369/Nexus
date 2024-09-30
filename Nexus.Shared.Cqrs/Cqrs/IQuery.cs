namespace Nexus.Shared.Mediator.Cqrs;

public interface IQuery
{
}

public interface IQuery<out T>  : IQuery
{
}