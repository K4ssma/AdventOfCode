namespace Kassma.AdventOfCode.ConsoleApp;

using System.Net;
using System.Text;
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
    /// <returns>
    ///     Returns a <see cref="Task"/> which succeeds when the app finished running.
    /// </returns>
    public async Task Run()
    {
        while (true)
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
                Console.WriteLine(
                    "Please enter your Advent of Code session cookie" +
                    " in order to authentificate against the Advent of Code Server");

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
                .Select((aocDay, index) => aocDay is null ? default(byte?) : (byte)(index + 1))
                .Where((index) => index is not null)
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

            var partInputPrompt =
                "Please enter the number of the part of the daily challenge you want to solve.\r\n"
                + "You can either solve the first or the second part.\r\n"
                + "1, 2";
            var choseFirstPart = this.GetValidUserInput(
                partInputPrompt,
                [true, false],
                (inputString) =>
                {
                    return inputString switch
                    {
                        "1" => true,
                        "2" => false,
                        _ => default(bool?),
                    };
                });

            if (choseFirstPart is null)
            {
                return;
            }

            var clientHandler = new HttpClientHandler()
            {
                CookieContainer = new(),
            };

            clientHandler.CookieContainer.Add(
                new Uri(this.Config.BaseUrl),
                new Cookie("session", this.SessionCookie));

            var httpClient = new HttpClient(clientHandler);

            var response = await httpClient.GetAsync($"{this.Config.BaseUrl}/{chosenYear}/day/{chosenDay}/input");

            if (!response.IsSuccessStatusCode)
            {
                this.SessionCookie = null;
                Console.WriteLine("Could not retrieve input. Your session cookie may be wrong.");
                continue;
            }

            var inputString = await response.Content.ReadAsStringAsync();

            var statusUpdates = new Queue<ProgressStatus>();

            var progress = new Progress<ProgressStatus>((status) =>
            {
                statusUpdates.Enqueue(status);
            });

            var solvingTask = Task.Run(() =>
            {
                return choseFirstPart.Value
                    ? this.AocYears[chosenYear.Value][chosenDay.Value - 1]!.SolvePart01(progress, inputString)
                    : this.AocYears[chosenYear.Value][chosenDay.Value - 1]!.SolvePart02(progress, inputString);
            });

            var spinnerPhase = 0;
            var completedHeadStates = 0;
            var completedStates = 0;
            var currCompletionPercent = 0;

            Console.Clear();

            var stringBuilder = new StringBuilder("\r\n[");
            for (var i = 0; i < this.Config.ProgressBarWidth; i++)
            {
                stringBuilder.Append('.');
            }

            stringBuilder.Append("] |   0%");

            Console.WriteLine(stringBuilder.ToString());

            while (!solvingTask.IsCompleted || statusUpdates.Count > 0)
            {
                Thread.Sleep(100);

                var nextSpinner = spinnerPhase switch
                {
                    0 => '|',
                    1 => '/',
                    2 => '-',
                    3 => '\\',
                    _ => 'e',
                };

                spinnerPhase = (spinnerPhase + 1) % 4;

                if (statusUpdates.Count == 0)
                {
                    Console.SetCursorPosition(
                        3 + this.Config.ProgressBarWidth,
                        completedStates == 0 ? 0 : completedStates + 1);
                    Console.Write(nextSpinner);
                    Console.SetCursorPosition(0, completedStates + 2);

                    continue;
                }

                while (statusUpdates.Count > 0)
                {
                    var status = statusUpdates.Dequeue();

                    Console.SetCursorPosition(0, completedStates);
                    var statusMessage = status.IsHeadStatus
                        ? $"[{completedHeadStates + 1}] {status.StatusMessage}"
                        : $"    - {status.StatusMessage}";

                    if (status.IsHeadStatus)
                    {
                        completedHeadStates++;
                    }

                    completedStates++;
                    currCompletionPercent = status.StatusPercent;

                    Console.WriteLine(statusMessage.PadRight(Console.WindowWidth));
                }

                Console.SetCursorPosition(0, completedStates);
                Console.WriteLine(string.Empty.PadRight(Console.WindowWidth));

                var completedPercentBits = currCompletionPercent / (100 / this.Config.ProgressBarWidth);

                stringBuilder.Clear();
                stringBuilder.Append('[');

                for (var i = 0; i < completedPercentBits; i++)
                {
                    stringBuilder.Append('#');
                }

                for (var i = 0; i < this.Config.ProgressBarWidth - completedPercentBits; i++)
                {
                    stringBuilder.Append('.');
                }

                stringBuilder.Append($"] {nextSpinner} {currCompletionPercent.ToString().PadLeft(3)}%");

                Console.SetCursorPosition(0, completedStates == 0 ? 0 : completedStates + 1);
                Console.WriteLine(stringBuilder.ToString().PadRight(Console.WindowWidth));
                Console.SetCursorPosition(0, completedStates + 2);
            }

            Console.WriteLine("The solution is:");
            Console.WriteLine(solvingTask.Result);

            var input = Console.ReadLine();

            if (input != null
                && input.Equals(this.Config.ExitCode.ToString(), StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }
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
