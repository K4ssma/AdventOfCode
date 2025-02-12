namespace AdventOfCode;

using Microsoft.Extensions.Configuration;

internal static class Config
{
    public static IConfigurationRoot Instance
    {
        get
        {
            instance ??= new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@"..\appsettings.json")
                    .AddUserSecrets<Dummy>()
                    .Build();

            return instance;
        }
    }

    private static IConfigurationRoot? instance;

    private sealed class Dummy
    {
    }
}
