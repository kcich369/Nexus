using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nexus.Shared.Cqrs.Dispatcher;
using Nexus.Shared.Cqrs.Interceptors;
using Nexus.Shared.Cqrs.Interfaces;
using Nexus.Shared.Cqrs.Resolvers;

namespace Nexus.Shared.Mediator;

public static class RegisterMediator
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
                .WithScopedLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(ICommandHandler<,>)); })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(ICommandValidator<,>)); })
                .AsImplementedInterfaces()
                .WithTransientLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(IInboundCommandInterceptor<>)); })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(IOutboundCommandInterceptor<>)); })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(IInboundQueryInterceptor<>)); })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(IOutboundQueryInterceptor<>)); })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        services.TryAddSingleton<CommandInterceptorsResolver>();
        services.TryAddSingleton<QueryInterceptorsResolver>();
        services.TryAddSingleton<ValidatorsResolver>();
        services.TryAddSingleton<HandlersResolver>();

        return services;
    }
}