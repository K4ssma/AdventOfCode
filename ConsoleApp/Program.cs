namespace Kassma.AdventOfCode.ConsoleApp;

using Kassma.AdventOfCode.Abstractions;
using Microsoft.Extensions.Configuration;

/// <summary>
///     Entry point of the Program.
/// </summary>
internal static class Program
{
    private static readonly Dictionary<ushort, IAocDay?[]> AocYears = [];

    private static async Task Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddUserSecrets<App>()
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        var uiConfig = config
            .GetSection("AppConfig")
            .Get<AppConfig>();

        var sessionCookie = config.GetSection("AdventOfCode")["SessionCookie"];

        ArgumentNullException.ThrowIfNull(uiConfig);

        var app = new App(uiConfig, sessionCookie, AocYears);

        await app.Run();
    }
}
