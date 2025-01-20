using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Nexus.Shared.DbManager;

public static class DbUpManager
{
    private const string Schema = "dbo";
    private const string FolderName = "Scripts";
    private const string TableName = "ExecutedScripts";

    public static void ExecuteScripts(string? connectionStringName = null)
    {
        var connectionString = ConfigurationBuilderHelper.GetConnectionStringValue(connectionStringName);
        EnsureDatabase.For.SqlDatabase(connectionString);

        var upgrader = DeployChanges.To
            .SqlDatabase(connectionString)
            .WithTransactionPerScript()
            .JournalToSqlTable(Schema, GetTableName())
            .WithScriptsFromFileSystem(FolderName)
            .LogToConsole()
            .Build();
        if (!upgrader.IsUpgradeRequired())
            return;

        var result = upgrader.PerformUpgrade();
        var text = result.Successful ? "Success!" : "Failure!!!";
        Console.WriteLine(text);
    }

    private static string GetTableName()
    {
        var projectName = Assembly.GetEntryAssembly()!.GetName().Name?.Split('.')[1];
        return $"{projectName}{TableName}";
    }
}