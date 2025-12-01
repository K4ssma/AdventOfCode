namespace Kassma.AdventOfCode.ConsoleApp;

using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     App-class, manages interaction with the user through the console lets the user solve Advent of Code challenges.
/// </summary>
/// <param name="config">
///     <see cref="AppConfig"/> which determines certain behaviour of this app.
/// </param>
/// <param name="aocYears">
///     Advent of Code challenge solvers grouped by their year and indexed by their day starting at index 0 = day 1.
/// </param>
internal sealed class App(AppConfig config, string? sessionCookie, Dictionary<ushort, IAocDay?[]> aocYears)
{
    /// <summary>
    ///     Gets the <see cref="AppConfig"/> used by this app, which determines certain behaviour of this instance.
    /// </summary>
    public AppConfig Config { get; init; } = config;

    /// <summary>
    ///     Gets the session cookie string for athentification against the advent of code website.
    /// </summary>
    public string? SessionCookie { get; private set; } = sessionCookie;

    /// <summary>
    ///     Gets the Advent of Code challenge solvers.
    ///     They are grouped by their year and indexed by their day starting at index 0 = day 1.
    /// </summary>
    public Dictionary<ushort, IAocDay?[]> AocYears { get; init; } = aocYears;

    /// <summary>
    ///     Starts this app.
    ///     This method may run indefinetly.
    /// </summary>
    public void Run()
    {
        var possibleYears = this.AocYears
            .Where((yearDictionary) => yearDictionary.Value.Length > 0)
            .ToDictionary();

        if (possibleYears.Count == 0)
        {
            Console.WriteLine("It seems like there are no solvers abailable :(");
            return;
        }

        if (string.IsNullOrEmpty(this.SessionCookie))
        {
            Console.WriteLine("It seems like there is no session cookie saved in the config.");
            Console.WriteLine("Please enter one now in order to authentificate against the Advent of Code Server");

            this.SessionCookie = Console.ReadLine();

            if (string.Equals(this.SessionCookie, this.Config.ExitCode.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }
        }

        var availableYearsString = possibleYears
            .Select((yearDictionary) => yearDictionary.Key.ToString())
            .Aggregate((curr, next) => curr + ", " + next);

        var yearInputPrompt =
            "Please choose the year of Advent of Code which challenges you want to solve.\r\n"
            + "The following years have solvers available:\r\n"
            + availableYearsString;

        var possibleAnswers = possibleYears
            .Select<KeyValuePair<ushort, IAocDay?[]>, ushort?>((yearDictionary) => yearDictionary.Key)
            .ToArray();

        var chosenYear = this.GetValidUserInput(
            yearInputPrompt,
            possibleAnswers,
            (inputString) => ushort.TryParse(inputString, out var parsedInput) ? parsedInput : null);

        if (chosenYear is null)
        {
            return;
        }

        var possibleDays = this.AocYears[chosenYear.Value]
            .Where((aocDay) => aocDay is not null)
            .Select((_, index) => (byte?)(index + 1))
            .ToArray();

        var availableDaysString = possibleDays
            .Select((index) => index.ToString())
            .Aggregate((curr, next) => curr + ", " + next);

        var dayInputPrompt =
            $"Please choose the day of Advent of Code {chosenYear.Value} you want to solve.\r\n"
            + "The following day have solvers available:\r\n"
            + availableDaysString;

        var chosenDay = this.GetValidUserInput(
            dayInputPrompt,
            possibleDays,
            (inputString) => byte.TryParse(inputString, out var parsedInput) ? parsedInput : null);

        if (chosenDay is null)
        {
            return;
        }

        chosenDay = (byte)(chosenDay - 1);
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
