using Microsoft.IdentityModel.Tokens;

namespace Nexus.Shared.DbScriptsManager;

public static class RegisterDbUp
{
    public static void Register(string? connectionStringName = null)
    {
        var config =ConfigurationBuilderHelper.CreateBuilder().Builds();
        var conncectionString = "";
        if(!connectionStringName.IsNullOrEmpty())
            conncectionString = config.GetConnectionString(connectionStringName);
        conncectionString = config.GetConnectionString();

    }
}