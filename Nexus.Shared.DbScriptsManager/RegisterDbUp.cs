using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Nexus.Shared.DbScriptsManager;

public static class RegisterDbUp
{
    private const string Schema = "dbo";
    private const string FolderName = "Scripts";
    private const string TableName = "ExecutedScripts";

    public static void Register(string? connectionStringName = null)
    {
        var connectionString = GetConnectionString(connectionStringName);
        
        EnsureDatabase.For.SqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .SqlDatabase(connectionString)
            .WithTransactionPerScript()
            .JournalToSqlTable(Schema, GetTableName())
            .WithScriptsFromFileSystem(FolderName)
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
        if (!string.IsNullOrEmpty(connectionStringName))
            connectionString = config.GetConnectionString(connectionStringName!);
        connectionString = config.GetConnectionString();

        return connectionString;
    }
    
    public static string GetTableName()
    {
        var projectName = Assembly.GetCallingAssembly().FullName?.Split('.')[1];
        return $"{projectName}{TableName}";
    }
}