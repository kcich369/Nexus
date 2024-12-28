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
        services.TryAddScoped<ICommandDispatcher, CommandDispatcher>();
        services.TryAddScoped<IQueryDispatcher, QueryDispatcher>();

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
                .WithScopedLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(IInboundCommandInterceptor<,>)); })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(IOutboundCommandInterceptor<,>)); })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(IInboundQueryInterceptor<,>)); })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        services.Scan(selector =>
        {
            selector.FromCallingAssembly()
                .AddClasses(filter => { filter.AssignableTo(typeof(IOutboundCommandInterceptor<,>)); })
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        
        return services;
    }
}