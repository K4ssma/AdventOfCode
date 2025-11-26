namespace Kassma.AdventOfCode.ConsoleApp;

/// <summary>
///     Record for storing app relevant configurations.
/// </summary>
internal sealed record UiConfig
{
    /// <summary>
    ///     Gets or sets the char, which the user can enter in order to exit the application at any given point.
    /// </summary>
    public required char ExitCode { get; set; }
}
