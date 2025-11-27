namespace Kassma.AdventOfCode.ConsoleApp;

/// <summary>
///     App-class, manages interaction with the user through the console lets the user solve Advent of Code challenges.
/// </summary>
/// <param name="config">
///     <see cref="UiConfig"/> which determines certain behaviour of this app.
/// </param>
internal sealed class App(UiConfig config)
{
    /// <summary>
    ///     Gets the <see cref="UiConfig"/> used by this app, which determines certain behaviour of this instance.
    /// </summary>
    public UiConfig Config { get; init; } = config;

    /// <summary>
    ///     Starts this app.
    ///     This method may run indefinetly.
    /// </summary>
    public void Run()
    {
        Console.WriteLine($"Note: You can stop the application at any point by entering \"{this.Config.ExitCode}\".");
    }
}
