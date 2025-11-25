namespace Kassma.AdventOfCode.ConsoleApp;

using Kassma.AdventOfCode.Abstractions;

/// <summary>
///     Mockup implementation of the <see cref="IAocDay"/>-interface for providing dummy data.
/// </summary>
internal sealed class AocDayMock : IAocDay
{
    /// <inheritdoc/>
    public static byte Day => 0;

    /// <inheritdoc/>
    public static string SolvePart01(string input)
    {
        Thread.Sleep(1000);

        return "Dummy result for part 01";
    }

    /// <inheritdoc/>
    public static string SolvePart02(string input)
    {
        Thread.Sleep(1000);

        return "Dummy result for part 02";
    }
}
