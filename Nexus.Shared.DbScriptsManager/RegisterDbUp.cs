using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Nexus.Shared.DbScriptsManager;

public static class RegisterDbUp
{
    private const string Schema = "dbo";
    private const string DirName = "dbo";

    public static void Register(string? connectionStringName = null, string? tableName = null)
    {
        var assemblyName = Assembly.GetCallingAssembly().FullName?.Split('.')[1];
        var connectionString = GetConnectionString(connectionStringName);
        EnsureDatabase.For.SqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .SqlDatabase(connectionString)
            .WithTransactionPerScript()
            .JournalToSqlTable("dbo", tableName)
            .WithScriptsFromFileSystem(DirName)
            .Build();

        if (!upgrader.IsUpgradeRequired())
            return;
        var result = upgrader.PerformUpgrade();
        var text = result.Successful ? "Success!" : "Failure!!!";
        Console.WriteLine(text);
    }

    private static string GetConnectionString(string? connectionStringName = null)
    {
        var config = ConfigurationBuilderHelper.CreateBuilder()
            .Build();

        var connectionString = "";
        if (!connectionStringName.IsNullOrEmpty())
            connectionString = config.GetConnectionString(connectionStringName!);
        connectionString = config.GetConnectionString();

        return connectionString;
    }
}