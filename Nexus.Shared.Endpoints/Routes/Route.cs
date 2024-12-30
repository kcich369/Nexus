using System.Text.RegularExpressions;

namespace Nexus.Shared.Endpoints.Routes;

public interface IRoute
{
}

public abstract class Route<T> : IRoute where T : IRoute
{
    private static string Main { get; set; } = typeof(T).Name;

    protected static ApiEndpointRoute CreateEndpoint(params string[] routes) => new ApiEndpointRoute(Main, routes);
}

public class ApiEndpointRoute
{
    public string Main { get; private set; }
    public string Route { get; private set; }

    public ApiEndpointRoute(string main, params string[] routes)
    {
        Main = SetMain(main);
        Route = string.Join("/", routes.Select(x => ToKebabCase(x.Trim())));
    }

    private static string SetMain(string main)
    {
        if (main.Contains("Route") || main.Contains("Routes"))
            main = main.Replace("Routes", string.Empty).Replace("Route", string.Empty);
        return main;
    }

    private static string ToKebabCase(string input)
    {
        var result = Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1-$2")
            .Replace("_", "-")
            .ToLower()
            .Trim('-');

        result = Regex.Replace(result, @"-+", "-");
        result = Regex.Replace(result, @"\{([a-zA-Z0-9]+)\}", m => "{" + m.Groups[1].Value + "}");

        return result;
    }

    protected static ApiEndpointRoute Create(string main, params string[] routes) => new ApiEndpointRoute(main, routes);
}