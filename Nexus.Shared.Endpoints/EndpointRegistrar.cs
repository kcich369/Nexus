using System.Reflection;
using Microsoft.AspNetCore.Routing;

namespace Nexus.Shared.Endpoints;

public static class EndpointRegistrar
{
    public static IEndpointRouteBuilder RegisterEndpoints(IEndpointRouteBuilder app)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        // && t.IsClass
        var endpointTypes = types
            .Where(t => typeof(Endpoint).IsAssignableFrom(t))
            .ToList();

        // && t.IsClass
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