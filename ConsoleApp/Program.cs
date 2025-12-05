namespace Kassma.AdventOfCode.ConsoleApp;

using Kassma.AdventOfCode.Abstractions;
using Kassma.AdventOfCode.Years.Year2025;
using Microsoft.Extensions.Configuration;

/// <summary>
///     Entry point of the Program.
/// </summary>
internal static class Program
{
    private static readonly Dictionary<ushort, IAocDay?[]> AocYears = new()
    {
        [2025] = [
            new Day01(),
            new Day02(),
            new Day03(),
            new Day04(),
            new Day05(),
        ],
    };

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
