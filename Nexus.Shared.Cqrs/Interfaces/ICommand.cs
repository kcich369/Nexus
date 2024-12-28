namespace Nexus.Shared.Cqrs.Interfaces;

public interface ICommand
{
}

public interface ICommand<out T> : ICommand
{
}