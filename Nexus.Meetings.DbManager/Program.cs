using Nexus.Shared.DbManager;

Console.WriteLine("Starting...");

DbUpManager.ExecuteScripts();

Console.WriteLine("Ended. Press key to exit.");
Console.ReadKey();