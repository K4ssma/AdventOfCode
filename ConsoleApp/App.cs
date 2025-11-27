namespace Kassma.AdventOfCode.ConsoleApp;

using System.Text;
using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     App-class, manages interaction with the user through the console lets the user solve Advent of Code challenges.
/// </summary>
/// <param name="config">
///     <see cref="UiConfig"/> which determines certain behaviour of this app.
/// </param>
/// <param name="aocYears">
///     Advent of Code challenge solvers grouped by their year and indexed by their day starting at index 0 = day 1.
/// </param>
internal sealed class App(UiConfig config, Dictionary<ushort, IAocDay[]> aocYears)
{
    /// <summary>
    ///     Gets the <see cref="UiConfig"/> used by this app, which determines certain behaviour of this instance.
    /// </summary>
    public UiConfig Config { get; init; } = config;

    /// <summary>
    ///     Gets the Advent of Code challenge solvers.
    ///     They are grouped by their year and indexed by their day starting at index 0 = day 1.
    /// </summary>
    public Dictionary<ushort, IAocDay[]> AocYears { get; init; } = aocYears;

    /// <summary>
    ///     Starts this app.
    ///     This method may run indefinetly.
    /// </summary>
    public void Run()
    {
        if (this.AocYears.Count == 0)
        {
            Console.WriteLine("\n\rIt seems like there are no solvers abailable :(");
            return;
        }

        Console.WriteLine($"Note: You can stop the application at any point by entering \"{this.Config.ExitCode}\".\r\n");
        Console.WriteLine("Please choose the year of Advent of Code which challenges you want to solve.");
        Console.WriteLine("The following years have solvers available:");

        var yearStrings = this.AocYears
            .Select((yearDictionary) => yearDictionary.Key.ToString());

        var stringBuilder = new StringBuilder();
        stringBuilder.AppendJoin(", ", yearStrings);

        Console.WriteLine(stringBuilder.ToString());
    }
}
