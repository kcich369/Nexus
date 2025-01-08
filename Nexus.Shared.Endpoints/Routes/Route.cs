using System.Text.RegularExpressions;

namespace Nexus.Shared.Endpoints.Routes;

public interface IRoute
{
}

public abstract class Route<T> : IRoute where T : IRoute
{
    protected static ApiEndpointRoute CreateRoute(params string[] routes) =>
        new ApiEndpointRoute(typeof(T).Name, routes);
}

public class ApiEndpointRoute
{
    public string Main { get; private set; }
    public string Route { get; private set; }

    public ApiEndpointRoute(string main, params string[] routes)
    {
        Main = ChangeMain(main);
        Route = string.Join("/", routes.Select(x => ToKebabCase(x.Trim())));
    }

    public string ChangeMain(string main)
    {
        if (main.Contains("Route") || main.Contains("Routes"))
            main = main.Replace("Routes", string.Empty).Replace("Route", string.Empty);
        Main = main;
        return Main;
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