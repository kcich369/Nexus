using Microsoft.AspNetCore.Routing;
using Nexus.Shared.Endpoints.Routes;

namespace Nexus.Shared.Endpoints.Abstractions;

public abstract class Endpoint(ApiEndpointRoute endpointRoute)
{
    protected string Route { get; set; } = $"{endpointRoute.Main}/{endpointRoute.Route}";

    protected abstract void Map(IEndpointRouteBuilder app); 
}