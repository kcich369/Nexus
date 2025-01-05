using System.Reflection;
using Microsoft.AspNetCore.Routing;
using Nexus.Shared.Endpoints.Abstractions;

namespace Nexus.Shared.Endpoints;

public static class EndpointRegistration
{
    public static IEndpointRouteBuilder RegisterEndpoints(this IEndpointRouteBuilder app)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        // && t.IsClass
        var endpointTypes = types
            .Where(t => typeof(Endpoint).IsAssignableFrom(t))
            .ToList();

        var derivedTypes = types
            .Where(t => endpointTypes.Any(x => x.IsAssignableFrom(t)))
            .ToList();

        foreach (var derivedType in derivedTypes)
        {
            var endpointInstance = (Endpoint)Activator.CreateInstance(derivedType, null)!;

            var mapMethod = derivedType.GetMethod("Map", BindingFlags.NonPublic | BindingFlags.Instance);
            mapMethod?.Invoke(endpointInstance, [app]);
        }

        return app;
    }
}