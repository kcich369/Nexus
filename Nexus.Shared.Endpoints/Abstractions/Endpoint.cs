using Microsoft.AspNetCore.Routing;
using Nexus.Shared.Endpoints.Routes;

namespace Nexus.Shared.Endpoints;

public abstract class Endpoint
{
    protected string Route { get; set; }

    protected Endpoint(ApiEndpointRoute endpointRoute)
    {
        Route = $"{endpointRoute.Main}/{endpointRoute.Route}";
    }
    
    protected abstract void Map(IEndpointRouteBuilder app); 
}