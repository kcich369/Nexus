using System.Collections.Immutable;
using Microsoft.Extensions.Configuration;

namespace Nexus.Shared.DbManager;

internal static class ConfigurationBuilderHelper
{
    private const string AppSettingsJson = "appsettings.json";
    private const string ConnectionStrings = "ConnectionStrings";

    public static string GetConnectionStringValue(string? connectionStringName = null)
    {
        var config = ConfigurationBuilderHelper.CreateBuilder()
            .Build();

        var connectionString = string.IsNullOrEmpty(connectionStringName)
            ? config.GetConnectionString()
            : config.GetConnectionString(connectionStringName!);

        return connectionString!;
    }

    public static IConfigurationBuilder CreateBuilder()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(AppSettingsJson, optional: false, reloadOnChange: true);

        return builder;
    }

    public static T BindSection<T>(this IConfiguration configuration, string? sectionName = null) where T : new()
    {
        var instance = new T();
        sectionName ??= GetSectionName(typeof(T).Name);
        configuration.GetSection(sectionName).Bind(instance);
        return instance;
    }

    private static readonly ImmutableList<string> ConfigClassNames =
        ImmutableList.Create("Configurations", "Configuration", "Config", "Section");

    private static string GetSectionName(string name)
    {
        if (!ConfigClassNames.Contains(name))
            return name;
        ConfigClassNames.ForEach(x => name = name.Replace(x, string.Empty));
        return name;
    }

    private static string GetConnectionString(this IConfiguration configuration)
    {
        var connectionStringsSection = configuration.GetSection(ConnectionStrings);
        var value = connectionStringsSection.GetChildren()
            .First()
            .Value;
        return value!;
    }
}