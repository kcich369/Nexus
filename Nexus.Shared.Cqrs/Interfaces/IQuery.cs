namespace Nexus.Shared.Cqrs.Interfaces;

public interface IQuery
{
}

public interface IQuery<out T>  : IQuery
{
}