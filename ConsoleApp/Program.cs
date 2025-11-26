namespace Kassma.AdventOfCode.ConsoleApp;

using Kassma.AdventOfCode.Abstractions;
using Kassma.AdventOfCode.ConsoleApp.Mocks;
using Microsoft.Extensions.Configuration;

/// <summary>
///     Entry point for the application.
/// </summary>
internal static class Program
{
    private static readonly IAocYear[] Years =
    [
        new AocYear(),
    ];

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

        Console.WriteLine(
            $"Note: You can enter \"{uiConfig.ExitCode}\" at any given time" +
            " in order to stop the application.\r\n");

        Console.WriteLine("Please enter the year of Advent of Code you would like to solve.");
        Console.WriteLine("The following years have an available solver:");

        for (var i = 0; i < Years.Length; i++)
        {
            Console.Write(Years[i].Year);

            if (i < Years.Length - 1)
            {
                Console.Write(", ");
            }
            else
            {
                Console.Write("\r\n");
            }
        }
    }
}
