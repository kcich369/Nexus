using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nexus.Shared.Mediator.Cqrs;
using Nexus.Shared.Mediator.Cqrs.Dispatcher;
using Nexus.Shared.Mediator.Cqrs.Interceptors;

namespace Nexus.Shared.Mediator;

public static class _RegisterMediator
{
    public static IServiceCollection RegisterCqrs(this IServiceCollection services)
    {
        services.TryAddSingleton<ICommandDispatcher, CommandDispatcher>();
        services.TryAddSingleton<IQueryDispatcher, QueryDispatcher>();

        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(IQueryHandler<,>)); })
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(ICommandHandler<,>)); })
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(ICommandValidator<,>)); })
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(ICommandInterceptor)); })
                .AsImplementedInterfaces()
                .WithSingletonLifetime();
        });

        services.AddSingleton<IQueryDispatcher, QueryDispatcher>()
            .Decorate<ICommandDispatcher, LoggingDispatcherDecorator>();
        return services;
    }
}