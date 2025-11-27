namespace Kassma.AdventOfCode.ConsoleApp;

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
            Console.WriteLine("It seems like there are no solvers abailable :(");
            return;
        }

        var availableYearsString = this.AocYears
            .Select((yearDictionary) => yearDictionary.Key.ToString())
            .Aggregate((curr, next) => curr + ", " + next);

        var yearInputPrompt =
            $"Note: You can stop the application at any point by entering \"{this.Config.ExitCode}\".\r\n\r\n"
            + "Please choose the year of Advent of Code which challenges you want to solve.\r\n"
            + "The following years have solvers available:\r\n"
            + availableYearsString;

        var possibleAnswers = this.AocYears
            .Select<KeyValuePair<ushort, IAocDay[]>, ushort?>((yearDictionary) => yearDictionary.Key)
            .ToArray();

        var chosenYear = this.GetValidUserInput<ushort?>(
            yearInputPrompt,
            possibleAnswers,
            (inputString) => ushort.TryParse(inputString, out var parsedInput) ? parsedInput : null);

        if (chosenYear is null)
        {
            return;
        }
    }

    private T? GetValidUserInput<T>(string userInputPrompt, ReadOnlySpan<T> possibleAnswers, Func<string, T?> userInputTryParser)
    {
        var isFirstPrompt = true;

        T? parsedInput = default;

        while (parsedInput is null
            || !possibleAnswers.Contains(parsedInput))
        {
            Console.Clear();
            Console.WriteLine($"Note: Enter \"{this.Config.ExitCode}\" in order to exit the application.\r\n");

            if (!isFirstPrompt)
            {
                Console.WriteLine("Invalid input please try again.\r\n");
            }

            isFirstPrompt = false;

            Console.WriteLine(userInputPrompt);

            var userInput = Console.ReadLine();
            if (userInput is null)
            {
                continue;
            }

            if (string.Equals(
                    userInput.Trim(),
                    this.Config.ExitCode.ToString(),
                    StringComparison.InvariantCultureIgnoreCase))
            {
                return default;
            }

            parsedInput = userInputTryParser(userInput);
        }

        return parsedInput;
    }
}
