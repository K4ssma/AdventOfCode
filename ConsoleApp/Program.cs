namespace Kassma.AdventOfCode.ConsoleApp;

using Microsoft.Extensions.Configuration;

/// <summary>
///     Entry point of the Program.
/// </summary>
internal static class Program
{
    private static void Main()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        var uiConfig = config
            .GetSection("UiConfig")
            .Get<UiConfig>();

        ArgumentNullException.ThrowIfNull(uiConfig);

        var app = new App(uiConfig);

        app.Run();
    }
}
